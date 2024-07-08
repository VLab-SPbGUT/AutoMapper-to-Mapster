namespace Application.DTO
{
    public sealed class ExerciseBlockDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Mark { get; set; }

        public MarkType MarkType { get; set; }

        public ExerciseType Type { get; set; }

        public ExerciseBlockSubType SubType { get; set; }

        public Guid LessonId { get; set; }

        public Content Theory { get; set; } = new Content();

        public Content GeneralInformation { get; set; } = new Content();
    }
}
