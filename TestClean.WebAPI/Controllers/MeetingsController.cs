
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestClean.Application.Dtos;
using TestClean.Application.Interfaces;
using TestClean.Application.Meeting.Commands;
using TestClean.Application.Meeting.Queries;


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
        [Authorize]
        public async Task<IActionResult> GetAllMeetings()
        {
/*            var meetings = await _meetingService.GetAllMeetingsAsync();
            if (meetings == null)
                return BadRequest("There is no meetings");
            return Ok(meetings);*/
            var meetings = await _mediator.Send(new GetAllMeetingsQuery());
            return Ok(meetings);

        }
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var meeting = await _mediator.Send(new GetMeetingByIdQuery { Id = id });
                if (meeting == null)
                    return BadRequest("No meeting by that Id exists");
                return Ok(meeting);
            }
            catch (Exception ex)
            {

                 Debug.WriteLine(ex.Message);
                throw;
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            try
            {
                var command = new DeleteMeeting { Id = id };
                var isDeleted = await _mediator.Send(command);

                if (isDeleted)
                {
                    return Ok("Meeting deleted successfully");
                }
                else
                {
                    return NotFound("Meeting not found");
                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
