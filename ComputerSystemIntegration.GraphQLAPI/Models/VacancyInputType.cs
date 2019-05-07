using GraphQL.Types;

namespace ComputerSystemIntegration.GraphQLAPI.Models
{
    public class VacancyInputType : InputObjectGraphType
    {
        public VacancyInputType()
        {
            Name = "VacancyInput";
            Field<NonNullGraphType<StringGraphType>>("author");
            Field<StringGraphType>("title");
            Field<StringGraphType>("description");
            Field<DateGraphType>("publishDate");
        }
    }
}
