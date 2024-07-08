
namespace Application.DTO
{
    public sealed class StudentDiscipline
    {
        public Guid Id { get; set; }

        public bool IsCredited { get; set; }

        public DateOnly? CreditedDate { get; set; }

        public string Name { get; set; } = string.Empty;

        public Status Status { get; set; }

        public int Year { get; set; }

        public int Semester { get; set; }

        public string TutorFiO { get; set; } = string.Empty;

        public Guid TutorId { get; set; }

        public Student? Student { get; set; }
    }
}
