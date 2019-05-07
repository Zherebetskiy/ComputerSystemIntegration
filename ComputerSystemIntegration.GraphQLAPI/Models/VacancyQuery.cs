using ComputerSystemIntegration.DataAccess.DAL;
using GraphQL.Types;

namespace ComputerSystemIntegration.GraphQLAPI.Models
{
    public class VacancyQuery : ObjectGraphType
    {
        public VacancyQuery(IRepository repository)
        {
            Field<ListGraphType<VacancyType>>(
                "vacancies",
                resolve: context => repository.GetAllAsync()
            );

            //Field<NewsType>(
            //    "newsById",
            //    arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "id" }),
            //    resolve: context => newsRepository.GetNewsById(context.GetArgument<string>("id"))
            //);
        }
    }
}
