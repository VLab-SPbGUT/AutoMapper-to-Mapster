namespace Application.DTO
{
    public sealed class ExerciseDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public ExerciseType Type { get; set; }

        public DateTime? CreditedTime { get; set; }

        public bool? IsCredited { get; set; }

        public Intensity Intensity { get; set; }

        public int ExerciseNumber { get; set; }

        public int? ExerciseVariant { get; set; }

        public MarkType MarkType { get; set; }

        public string? Mark { get; set; }

        public Status Status { get; set; } = Status.NotStatred;

        public Guid ExerciseBlockId { get; set; }

        public Content Example { get; set; } = new Content();

        public Content MethodicalInstructions { get; set; } = new Content();

        public List<AnswerDTO> Answers { get; set; } = [];

        public Test? Test { get; set; } = new Test();
    }
}
