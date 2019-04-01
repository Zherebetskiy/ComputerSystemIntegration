using System;

using ComputerSystemIntegration.Domain.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ComputerSystemIntegration.DataAccess.DAL
{
    public class NewsEntity : BaseEntity
    {
        [BsonId]
        public ObjectId InternalId { get; set; }
        public string Author { get; set; }
        [BsonDateTimeOptions]
        public DateTime PublishDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        [BsonDateTimeOptions]
        public DateTime UpdatedOn { get; set; } = DateTime.Now;
    }
}
