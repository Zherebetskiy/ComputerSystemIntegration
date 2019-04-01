using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerSystemIntegration.Domain.Interfaces
{
    public interface IRepository <T>
    {
        Task<ICollection<T>> GetAllAsync();
        Task AddNew(T entity);
    }
}
