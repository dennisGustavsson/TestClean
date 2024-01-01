using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestClean.Application.Dtos;
using TestClean.Application.Meeting.Queries;
using TestClean.Domain.Interfaces;

namespace TestClean.Application.Meeting.QueryHandlers;

public class GetAllMeetingsQueryHandler : IRequestHandler<GetAllMeetingsQuery, IEnumerable<MeetingDto>>
{
    private readonly IMeetingRepository _meetingRepo;

    public GetAllMeetingsQueryHandler(IMeetingRepository meetingRepo)
    {
        _meetingRepo = meetingRepo;
    }

    public async Task<IEnumerable<MeetingDto>> Handle(GetAllMeetingsQuery request, CancellationToken cancellationToken)
    {
        List<MeetingDto> dtosList = new();
        foreach(var item in await _meetingRepo.GetAllAsync())
        {
            dtosList.Add(new MeetingDto()
            {
                Id = item.Id,
                Title = item.Title,
                StartTime = item.StartTime,
                EndTime = item.EndTime,
            });
        }
        return dtosList;
    }
}
