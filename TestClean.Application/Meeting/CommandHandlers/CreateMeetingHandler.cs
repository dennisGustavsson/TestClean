using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore.Metadata;
using TestClean.Application.Dtos;
using TestClean.Application.Meeting.Commands;
using TestClean.Domain.Entities;
using TestClean.Domain.Interfaces;

namespace TestClean.Application.Meeting.CommandHandlers;

public class CreateMeetingHandler : IRequestHandler<CreateMeeting, MeetingDto>
{
    private readonly IMeetingRepository _meetingRepo;

    public CreateMeetingHandler(IMeetingRepository meetingRepo)
    {
        _meetingRepo = meetingRepo;
    }

    public async Task<MeetingDto> Handle(CreateMeeting request, CancellationToken cancellationToken)
    {
        var meeting = new MeetingEntity
        {
            Title = request.Title,
            StartTime = request.StartDate,
            EndTime = request.EndDate
        };
        await _meetingRepo.AddAsync(meeting);

        //mapping
        var meetingDto = new MeetingDto
        {
            Title = meeting.Title,
            StartTime = meeting.StartTime,
            EndTime = meeting.EndTime,
        };

        return meetingDto;
    }
}