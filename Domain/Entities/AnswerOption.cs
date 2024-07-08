namespace Domain.Entities
{
    public sealed class AnswerOption : BaseEntity
    {
        public AnswerFormat AnswerFormat { get; set; }

        public AnswerType OptionType { get; set; }

        public int OptionNumber { get; set; }

        public string? Description { get; set; }

        public Guid ExerciseId { get;set; }

        public Exercise Exercise { get; set; } = new Exercise();

        public Content Answer { get; set; } = new Content();
    }
}
