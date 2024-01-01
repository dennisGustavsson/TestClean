using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestClean.Application.Dtos;

namespace TestClean.Application.Meeting.Queries;

public class GetAllMeetingsQuery: IRequest<IEnumerable<MeetingDto>>
{
}
