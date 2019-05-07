using System;

namespace ComputerSystemIntegration.Domain.Models
{
    [Serializable]
    public class Vacancy
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string PublishDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return $"{Author} {Title} {PublishDate}";
        }
    }
}
