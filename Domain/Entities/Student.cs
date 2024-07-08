namespace Domain.Entities
{
    public sealed class Student : BaseEntity
    {
        public string ShortName { get; set; } = string.Empty;

        public string PhotoUrl { get; set; } = string.Empty;

        public int Variant { get; set; }
        
        public string GroupNumber { get; set; } = string.Empty;
    }
}
