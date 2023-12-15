
using Microsoft.EntityFrameworkCore;
using TestClean.Domain.Entities;
using TestClean.Domain.Interfaces;

using TestClean.Infrastructure.Data;

namespace TestClean.Infrastructure.Repositories;



public class MeetingRepository : Repository<MeetingEntity>, IMeetingRepository
{
    public MeetingRepository(DataContext context) : base(context)
    {
    }
}
