﻿using MongoDB.Driver;

namespace ComputerSystemIntegration.DataAccess.DAL
{
    public class DbContext
    {
        private readonly IMongoDatabase database = null;

        public DbContext(MongoConfig config)
        {
            var client = new MongoClient(config.ConnectionString);
            if (client != null)
                database = client.GetDatabase(config.Database);
        }
        public IMongoCollection<NewsEntity> News
        {
            get
            {
                return database.GetCollection<NewsEntity>("news");
            }
        }
    }
}
