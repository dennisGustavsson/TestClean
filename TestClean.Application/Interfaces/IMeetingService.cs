using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestClean.Application.Dtos;
using TestClean.Domain.Entities;

namespace TestClean.Application.Interfaces;

public interface IMeetingService
{
    Task<MeetingEntity> CreateMeetingAsync(MeetingDto meetingDto);
}
