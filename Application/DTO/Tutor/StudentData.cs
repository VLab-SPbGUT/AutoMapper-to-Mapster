namespace Application.DTO.Tutor
{
    public class StudentData
    {
        public Guid StudentId { get; set; }
        
        public Guid LessonId { get; set; }
        
        public int WorksDone { get; set; }

        public string StudentName { get; set; } = null!;
        
        public int WorksCount { get; set; }
        
        public Status Status { get; set; }
    }
}