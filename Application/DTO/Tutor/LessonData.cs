namespace Application.DTO.Tutor
{
    public class LessonData
    {
        public int VariantNumber { get; set; }

        public List<ExerciseBlockData> ExerciseBlocksData { get; set; } = [];
    }
}