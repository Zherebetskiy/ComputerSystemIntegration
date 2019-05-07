using ComputerSystemIntegration.DataAccess.DAL;
using ComputerSystemIntegration.Domain.Models;
using GraphQL.Types;

namespace ComputerSystemIntegration.GraphQLAPI.Models
{
    public class VacancyMutation : ObjectGraphType
    {
        public VacancyMutation(IRepository repository)
        {
            Field<VacancyType>(
                "addNew",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<VacancyInputType>> { Name = "vacancy" }
                ),
                resolve: context =>
                {
                    var n = context.GetArgument<Vacancy>("vacansy");
                    return repository.AddNew(n);
                });
        }
    }
}
