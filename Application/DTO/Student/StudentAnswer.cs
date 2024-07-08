namespace Application.DTO
{
    public sealed class StudentAnswer
    {
        public AnswerFormat AnswerFormat { get; set; }

        public AnswerType OptionType { get; set; }

        public int OptionNumber { get; set; }

        public string? Description { get; set; }

        public Guid ExerciseId { get; set; }

        public Content Answer { get; set; } = new Content();
    }
}
