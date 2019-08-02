using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CollegeApi.DataBase
{
    public class CollegeApiContextFactory : IDesignTimeDbContextFactory<CollegeApiContext>
    {
        public CollegeApiContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            var builder = new DbContextOptionsBuilder<CollegeApiContext>();
            var connectionString = configuration.GetConnectionString("CollegeApiDb");
            builder.UseSqlServer(connectionString);

            return new CollegeApiContext(builder.Options);
        }
    }
}
