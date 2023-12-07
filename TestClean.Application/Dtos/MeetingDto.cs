namespace TestClean.Application.Dtos
{
    public class MeetingDto
    {
        public string Title { get; set; } = null!;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        // Add other properties as needed
    }
}
