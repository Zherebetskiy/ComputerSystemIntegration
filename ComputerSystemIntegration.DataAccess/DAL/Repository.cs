using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ComputerSystemIntegration.Domain.Interfaces;
using ComputerSystemIntegration.Domain.Models;
using MongoDB.Driver;

namespace ComputerSystemIntegration.DataAccess.DAL
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DbContext context;
        private readonly IMapper mapper;
        public Repository(MongoConfig config, IMapper mapper)
        {
            context = new DbContext(config);
            this.mapper = mapper;
        }

        public async Task AddNew(T entity)
        {
            try
            {
                await context.News.InsertOneAsync(mapper.Map<NewsEntity>(entity));//??? 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            var documents = await context.News.Find(_ => true).ToListAsync();
            return mapper.Map<ICollection<T>>(documents);
        }
    }
}
