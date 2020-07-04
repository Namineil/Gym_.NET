using System.Collections.Generic;
using System.Threading.Tasks;
using Gym.API.Domain.Models;
using Gym.API.Domain.Services.Communication;

namespace Gym.API.Domain.Services
{
    public interface IClassRecordsService
    {
        Task<IEnumerable<ClassRecords>> ListAsync();
        Task<ClassRecordsResponse> SaveAsync(ClassRecords classRecords);
        Task<ClassRecordsResponse> UpdateAsync(int id, ClassRecords classRecords);
        Task<ClassRecordsResponse> DeleteAsync(int id);
    }
}