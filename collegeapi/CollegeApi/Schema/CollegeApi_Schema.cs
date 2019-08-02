using CollegeApi.Mutations;
using CollegeApi.Queries;
using GraphQL;

namespace CollegeApi.Schema
{
    public class CollegeApi_Schema : GraphQL.Types.Schema
    {
        public CollegeApi_Schema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<CollegeApi_Queries>();
            Mutation = resolver.Resolve<CollegeApi_Mutations>();
        }
    }
}
