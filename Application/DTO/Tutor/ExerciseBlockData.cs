namespace Application.DTO.Tutor
{
    public class ExerciseBlockData
    {
        public string Name { get; set; } = null!;
        
        public ExerciseBlockSubType Type { get; set; }
        
        public Guid ExerciseBlockId { get; set; }
        
        public Status Status { get; set; }
        
        public int WorksDone { get; set; }  
        
        public int WorksLeft { get; set; }
        
        public int WorksOnReview { get; set; }
    }
}