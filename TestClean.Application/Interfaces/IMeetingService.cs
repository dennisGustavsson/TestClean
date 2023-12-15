
using TestClean.Application.Dtos;
using TestClean.Domain.Entities;

namespace TestClean.Application.Interfaces;

public interface IMeetingService
{
    Task<MeetingEntity> CreateMeetingAsync(MeetingDto meetingDto);
    Task<List<MeetingDto>> GetAllMeetingsAsync();
}
