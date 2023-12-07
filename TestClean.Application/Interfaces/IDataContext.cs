using Microsoft.EntityFrameworkCore;
using TestClean.Domain.Entities;

namespace TestClean.Application.Interfaces;

public interface IDataContext
{
    DbSet<MeetingEntity> Meetings { get; }
}
