using System;

namespace ComputerSystemIntegration.Domain.Models
{
    public class News : BaseEntity
    {
        public string Author { get; set; }
        public DateTime PublishDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
    }
}
