using MediatR;
using TestClean.Application.Dtos;
using TestClean.Application.Meeting.Commands;
using TestClean.Domain.Interfaces;

namespace TestClean.Application.Meeting.CommandHandlers;

public class DeleteMeetingHandler : IRequestHandler<DeleteMeeting, bool>
{
    private readonly IMeetingRepository _meetingRepo;

    public DeleteMeetingHandler(IMeetingRepository meetingRepo)
    {
        _meetingRepo = meetingRepo;
    }

    public async Task<bool> Handle(DeleteMeeting request, CancellationToken cancellationToken)
    {
        var meeting = await _meetingRepo.GetByIdAsync(request.Id);

        if (meeting == null)
        {
            // Meeting not found
            return false;
        }

        await _meetingRepo.DeleteAsync(meeting.Id);

        // You can return true to indicate successful deletion
        return true;
    }
}
