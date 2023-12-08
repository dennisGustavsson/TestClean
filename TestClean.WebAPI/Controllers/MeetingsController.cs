
using Microsoft.AspNetCore.Mvc;
using TestClean.Application.Dtos;
using TestClean.Application.Interfaces;


namespace TestClean.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingsController : ControllerBase
    {
        private readonly IMeetingService _meetingService;

        public MeetingsController(IMeetingService meetingService)
        {
            _meetingService = meetingService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMeeting([FromBody]MeetingDto meeting)
        {

            if(meeting == null)
            {
                return BadRequest("Meeting data is null");
            }

            var _meeting = await _meetingService.CreateMeetingAsync(meeting);
            return Created("", _meeting);

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
