using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestClean.Application.Dtos;
using TestClean.Application.Meeting.Queries;
using TestClean.Domain.Entities;
using TestClean.Domain.Interfaces;

namespace TestClean.Application.Meeting.QueryHandlers
{
    public class GetMeetingByIdQueryHandler : IRequestHandler<GetMeetingByIdQuery, MeetingDto>
    {
        private readonly IMeetingRepository _meetingRepo;

        public GetMeetingByIdQueryHandler(IMeetingRepository meetingRepo)
        {
            _meetingRepo = meetingRepo;
        }

        public async Task<MeetingDto> Handle(GetMeetingByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var meeting = await _meetingRepo.GetByIdAsync(request.Id);
                if(meeting is not null)
                {
                    return new MeetingDto()
                    {
                        Id = meeting.Id,
                        Title = meeting.Title,
                        StartTime = meeting.StartTime,
                        EndTime = meeting.EndTime
                    };
                } return null!;

            }
            catch (Exception)
            {

                throw new Exception($"error error");
            }
        }
    }
}
