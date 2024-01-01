using MediatR;
using TestClean.Application.Dtos;

namespace TestClean.Application.Meeting.Queries;

public class GetMeetingByIdQuery : IRequest<MeetingDto>
{
    public int Id { get; set; }
}
