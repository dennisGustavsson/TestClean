using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestClean.Domain.Entities;

namespace TestClean.Domain.Interfaces
{
    public interface IMeetingRepository
    {
            
        Task<MeetingEntity> GetByIdAsync(int id);
        Task<IEnumerable<MeetingEntity>> GetAllAsync();
        Task AddAsync(MeetingEntity meeting);
        Task UpdateAsync(MeetingEntity meeting);
        Task DeleteAsync(int id);
        // Add other methods as needed
    }
}

