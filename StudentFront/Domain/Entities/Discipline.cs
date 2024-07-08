namespace Domain.Entities
{
    public sealed class Discipline : BaseEntity
    {
        public int Year { get; set; }

        public int Semester { get; set; }

        public string TutorFIO { get; set; } = string.Empty;

        public Guid TutorId { get; set; }

        public Student Student { get; set; } = new Student();

        public List<Lesson> Lessons { get; set; } = [];
    }
}
