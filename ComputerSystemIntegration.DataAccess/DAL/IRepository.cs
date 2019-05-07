using ComputerSystemIntegration.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerSystemIntegration.DataAccess.DAL
{
    public interface IRepository
    {
        Task<IList<Vacancy>> GetAllAsync();
        Task AddNew(Vacancy vacancy);
        Task<Vacancy> Find(Vacancy vacancy);
    }
}
