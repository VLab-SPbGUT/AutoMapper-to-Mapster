global using Domain.Entities;
global using Domain.Enums;
global using Domain.ValueObjects;
global using Application.DTO;

namespace Application.DTO
{
    public sealed class AnswerDTO
    {
        public AnswerFormat AnswerFormat { get; set; }

        public AnswerType OptionType { get; set; }

        public int OptionNumber { get; set; }

        public string? Description { get; set; }

        public Guid ExerciseId { get; set; }

        public Content Answer { get; set; } = new Content();
    }
}
