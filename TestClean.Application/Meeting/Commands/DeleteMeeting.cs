using MediatR;
using TestClean.Application.Dtos;

namespace TestClean.Application.Meeting.Commands;

public class DeleteMeeting : IRequest<bool>
{
    public int Id { get; set; }
}
