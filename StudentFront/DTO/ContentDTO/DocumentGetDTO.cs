namespace StudentFront.DTO.ContentDTO
{
    public class DocumentGetDTO
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string Content { get; set; } = string.Empty;

        public string? Description { get; set; }

        public DateOnly CreatedDate { get; set; }

        public DateOnly? UpdatedDate { get; set; }

        public List<LinkedResources> Resources { get; set; } = [];
    }
}