namespace Domain.Entities
{
    public class ExerciseBlock : BaseEntity
    {
        public bool IsCredited { get; set; } = false;

        public DateOnly? CreditedDate { get; set; }

        public string? Mark {  get; set; }

        public MarkType MarkType { get; set; }

        public ExerciseType Type { get; set; }

        public Status Status { get; set; } = Status.NotStarted;

        public ExerciseBlockSubType SubType { get; set; }

        public Guid LessonId { get; set; }  

        public Lesson Lesson { get; set; } = new Lesson();

        public Content Theory {  get; set; } = new Content();

        public Content GeneralInformation { get; set; } = new Content();

        public List<Exercise> Exercises { get; set; } = [];
    }
}
