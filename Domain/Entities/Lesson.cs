namespace Domain.Entities
{
    public sealed class Lesson : BaseEntity
    {
        public int LessonNumber { get; set; }

        public MarkType MarkType { get; set; }

        public string? Mark { get; set; }

        public bool? IsCredited { get; set; }

        public DateOnly? CreditedDate {  get; set; }

        public Intensity Intensity { get; set; }

        public Guid TutorId { get; set; }
        
        public LessonType Type { get; set; }

        public Status Status { get; set; } = Status.NotStarted;

        public Guid DisciplineId { get; set; }

        public Discipline Discipline { get; set; } = new Discipline();

        public Content? Theory { get; set; }

        public List<ExerciseBlock> ExerciseBlocks { get; set; } = [];
    }
}
