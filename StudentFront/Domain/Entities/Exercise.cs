global using Domain.Common;
global using Domain.Enums;
global using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Exercise : BaseEntity
    {
        public ExerciseType Type { get; set; }

        public DateTime? CreditedTime { get; set; }

        public bool? IsCredited { get; set; }

        public Intensity Intensity { get; set; }

        public int ExerciseNumber { get; set; }

        public int? ExerciseVariant { get; set; }

        public MarkType MarkType { get; set; }

        public string? Mark {  get; set; }

        public Status Status { get; set; } = Status.NotStatred;

        public Guid ExerciseBlockId { get; set; }

        public ExerciseBlock ExerciseBlock { get; set; } = new ExerciseBlock();

        public Content Example { get; set; } = new Content();   

        public Content MethodicalInstructions { get; set; } = new Content();

        public List<AnswerOption> Answers { get; set; } = [];

        public Test? Test { get; set; } = new Test();
    }
}
