namespace Application.DTO
{
    public sealed class DisciplineDTO
    {
        public Guid Id {  get; set; }

        public string Name { get; set; } = string.Empty;

        public int Year { get; set; }

        public int Semester { get; set; }

        public string TutorFiO { get; set; } = string.Empty;

        public Guid TutorId { get; set; }

        public Student? Student { get; set; }  
    }
}
