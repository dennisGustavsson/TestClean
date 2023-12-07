using System;
using TestClean.Application.Dtos;
using TestClean.Application.Interfaces;
using TestClean.Domain.Entities;
using TestClean.Domain.Interfaces;

namespace TestClean.Application.Services;

public class MeetingService : IMeetingService
{
    private readonly IMeetingRepository _meetingRepo;

    public MeetingService(IMeetingRepository meetingRepo)
    {
        _meetingRepo = meetingRepo;
    }

    public async Task<MeetingEntity> CreateMeetingAsync(MeetingDto meetingDto)
    {
        if (meetingDto != null)
        {
            MeetingEntity entity = new()
            {
                Title = meetingDto.Title,
                StartTime = DateTime.Now,
                EndTime = DateTime.Now,
            };
            await _meetingRepo.AddAsync(entity);
            return entity;
        }

        return null!;
    }
}
