namespace Application.DTO
{
    public sealed class LessonDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int LessonNumber { get; set; }

        public MarkType MarkType { get; set; }

        public string? Mark { get; set; }

        public bool? IsCredited { get; set; }

        public DateTime? CreditedTime { get; set; }

        public Intensity Intensity { get; set; }

        public LessonType Type { get; set; }

        public Status Status { get; set; } = Status.NotStatred;

        public Guid DisciplineId { get; set; }

        public Content? Theory { get; set; }
    }
}
