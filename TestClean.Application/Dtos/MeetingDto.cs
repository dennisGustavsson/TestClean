using TestClean.Domain.Entities;

namespace TestClean.Application.Dtos
{
    public class MeetingDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        // Add other properties as needed


        public static implicit operator MeetingEntity(MeetingDto dto)
        {
            return new MeetingEntity
            {
                Title = dto.Title,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime,
            };
        }
    }
}
