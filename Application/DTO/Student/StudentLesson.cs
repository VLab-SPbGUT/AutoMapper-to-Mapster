namespace Application.DTO
{
    public sealed class StudentLesson
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int LessonNumber { get; set; }

        public MarkType MarkType { get; set; }

        public string? Mark { get; set; }

        public bool IsCredited { get; set; }

        public Guid TutorId { get; set; }
        
        public DateOnly? CreditedDate { get; set; }

        public Intensity Intensity { get; set; }

        public LessonType Type { get; set; }

        public Status Status { get; set; } = Status.NotStarted;

        public Guid DisciplineId { get; set; }

        public Content? Theory { get; set; }
    }
}
