

using MediatR;
using TestClean.Application.Dtos;


namespace TestClean.Application.Meeting.Commands;

public class CreateMeeting : IRequest<MeetingDto>
{
    public string Title { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
};
