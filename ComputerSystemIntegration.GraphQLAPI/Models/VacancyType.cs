using ComputerSystemIntegration.Domain.Models;
using GraphQL.Types;

namespace ComputerSystemIntegration.GraphQLAPI.Models
{
    public class VacancyType : ObjectGraphType<Vacancy>
    {
        public VacancyType()
        {
            Field(x => x.Id, true);
            Field(x => x.Author, true);
            Field(x => x.Title);
            Field(x => x.Description, true);
            Field(x => x.PublishDate, true);
           // Field(x => x.Comments, type: typeof(ListGraphType<CommentType>));
        }
    }
}
