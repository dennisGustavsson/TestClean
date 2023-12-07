using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestClean.Domain.Entities;

public class MeetingEntity
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    // Add other properties as needed
}
