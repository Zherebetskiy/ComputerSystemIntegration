using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ComputerSystemIntegration.DataAccess.DAL
{
    public class VacancyEntity 
    {
        [BsonId]
        public ObjectId InternalId { get; set; }
        public int Id { get; set; }
        public string Author { get; set; }
        public string PublishDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [BsonDateTimeOptions]
        public DateTime UpdatedOn { get; set; } = DateTime.Now;
    }
}
