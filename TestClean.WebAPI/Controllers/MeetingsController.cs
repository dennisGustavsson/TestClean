
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TestClean.Application.Dtos;
using TestClean.Application.Interfaces;
using TestClean.Application.Meeting.Commands;


namespace TestClean.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingsController : ControllerBase
    {
        private readonly IMeetingService _meetingService;
        private readonly IMediator _mediator;

        public MeetingsController(IMeetingService meetingService, IMediator mediator)
        {
            _meetingService = meetingService;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMeeting([FromBody]MeetingDto meetingDto)
        {

            if(meetingDto == null)
            {
                return BadRequest("Meeting data is null");
            }

            var command = new CreateMeeting
            {
                Title = meetingDto.Title,
                StartDate = meetingDto.StartTime,
                EndDate = meetingDto.EndTime
            };

            var meeting = await _mediator.Send(command);
            return Created("Meeting created", meeting);

        }

        [HttpGet]
        public async Task<IActionResult> GetAllMeetings()
        {
            var meetings = await _meetingService.GetAllMeetingsAsync();
            if (meetings == null)
                return BadRequest("There is no meetings");
            return Ok(meetings);
        }
    }
}
