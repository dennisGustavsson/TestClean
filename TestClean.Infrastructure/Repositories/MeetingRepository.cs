
using Microsoft.EntityFrameworkCore;
using TestClean.Domain.Entities;
using TestClean.Domain.Interfaces;

using TestClean.Infrastructure.Data;

namespace TestClean.Infrastructure.Repositories;



public class MeetingRepository : IMeetingRepository
{

    private readonly DataContext _context;

    public MeetingRepository(DataContext context)
    {
        _context = context;
    }

    public async Task AddAsync(MeetingEntity meeting)
    {
        _context.Meetings.Add(meeting);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var meeting = await GetByIdAsync(id);
        if (meeting != null)
        {
            _context.Meetings.Remove(meeting); 
           await _context.SaveChangesAsync();
        }
        
    }

    public async Task<IEnumerable<MeetingEntity>> GetAllAsync()
    {
        return await _context.Meetings.ToListAsync();
    }

    public async Task<MeetingEntity> GetByIdAsync(int id)
    {
        var meetingExists = await _context.Meetings.FindAsync(id);
        if (meetingExists == null) { return null!;  }
        return meetingExists;

    }

    public async Task UpdateAsync(MeetingEntity meeting)
    {
        _context.Meetings.Update(meeting);
        await _context.SaveChangesAsync();
    }
}
