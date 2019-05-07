using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ComputerSystemIntegration.Domain.Models;
using MongoDB.Driver;

namespace ComputerSystemIntegration.DataAccess.DAL
{
    public class Repository : IRepository
    {
        private readonly DbContext context;
        private readonly IMapper mapper;
        public Repository(MongoConfig config, IMapper mapper)
        {
            context = new DbContext(config);
            this.mapper = mapper;
        }

        public async Task AddNew(Vacancy entity)
        {
            try
            {
                if (await Find(entity) == null)
                {
                    await context.Vacancies.InsertOneAsync(mapper.Map<VacancyEntity>(entity));
                }
                else
                {
                    return;
                }
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Vacancy> Find(Vacancy vacancy)
        {
            var documents = await context.Vacancies.Find(v => v.Description == vacancy.Description).ToListAsync();
            var findDocument = documents.FirstOrDefault();

            return findDocument != null ? mapper.Map<Vacancy>(findDocument) : null;
        }

        public async Task<IList<Vacancy>> GetAllAsync()
        {
            var documents = await context.Vacancies.Find(_ => true).ToListAsync();
            return mapper.Map<IList<Vacancy>>(documents);
        }
    }
}
