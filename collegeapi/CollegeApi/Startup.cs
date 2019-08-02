using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CollegeApi.DataAccess.Repositories;
using CollegeApi.DataAccess.Repositories.Contracts;
using CollegeApi.DataBase;
using CollegeApi.Mutations;
using CollegeApi.Queries;
using CollegeApi.Schema;
using CollegeApi.Types.DetalleNota;
using CollegeApi.Types.Estudiante;
using CollegeApi.Types.Materia;
using GraphiQl;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CollegeApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //Metodos de Capa de Datos (DAO)
            services.AddTransient<IEstudiante_Repository, Estudiante_Repository>();
            services.AddTransient<IMateria_Repository, Materia_Repository>();
            services.AddTransient<IDetalleNota_Repository, DetalleNota_Repository>();

            //Contexto de Conexion de Base de Datos
            services.AddDbContext<CollegeApiContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:CollegeApiDb"]));

            //Document Executer GraphQl
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();

            //Queries de GraphQl
            services.AddSingleton<CollegeApi_Queries>();

            //Mutaciones de GraphQl
            services.AddSingleton<CollegeApi_Mutations>();

            //Resolvers de Queries de GraphQl
            services.AddSingleton<Estudiante_Type>();
            services.AddSingleton<Materia_Type>();
            services.AddSingleton<DetalleNota_Type>();

            //Resolvers de Mutations de GraphQl
            services.AddSingleton<Estudiante_InputType>();
            services.AddSingleton<Materia_InputType>();
            services.AddSingleton<DetalleNota_InputType>();

            //Construir Servicios
            var sp = services.BuildServiceProvider();

            //Schema GraphQl
            services.AddSingleton<ISchema>(new CollegeApi_Schema(new FuncDependencyResolver(type => sp.GetService(type))));


            services.AddGraphQL(x =>
            {
                x.ExposeExceptions = true; //set true only in dev mode.
            })
                .AddGraphTypes(ServiceLifetime.Scoped)
                .AddUserContextBuilder(httpContext => httpContext.User)
                .AddDataLoader();

            services.AddCors(options =>
            {
                options.AddPolicy("Reglas",
                builder =>
                {
                    builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, CollegeApiContext db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions()); //to explorer API navigate https://*DOMAIN*/ui/playground
            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseCors("Reglas");
            db.EnsureSeedData();
        }
    }
}
