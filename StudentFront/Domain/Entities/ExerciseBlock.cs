namespace Domain.Entities
{
    public class ExerciseBlock : BaseEntity
    {
        public string? Mark {  get; set; }

        public MarkType MarkType { get; set; }

        public ExerciseType Type { get; set; }

        public ExerciseBlockSubType SubType { get; set; }

        public Guid LessonId { get; set; }  

        public Lesson Lesson { get; set; } = new Lesson();

        public Content Theory {  get; set; } = new Content();

        public Content GeneralInformation { get; set; } = new Content();

        public List<Exercise> Exercises { get; set; } = [];
    }
}
