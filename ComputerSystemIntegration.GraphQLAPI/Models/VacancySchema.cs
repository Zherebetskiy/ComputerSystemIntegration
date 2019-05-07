using GraphQL;
using GraphQL.Types;

namespace ComputerSystemIntegration.GraphQLAPI.Models
{
    public class VacancySchema : Schema
    {
        public VacancySchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<VacancyQuery>();
            Mutation = resolver.Resolve<VacancyMutation>();
        }
    }
}
