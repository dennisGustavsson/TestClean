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

    public async Task<List<MeetingDto>> GetAllMeetingsAsync()
    {

        List<MeetingDto> list = new();

        foreach(var item in await _meetingRepo.GetAllAsync())
        {
            MeetingDto dto = new()
            {
                Id = item.Id,
                Title = item.Title,
                StartTime = DateTime.Now,
                EndTime = DateTime.Now,
            };
            list.Add(dto);

        }
        return list;

    }
}
