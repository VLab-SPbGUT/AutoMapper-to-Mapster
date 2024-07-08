namespace StudentFront.DTO.ContentDTO
{
    public enum ResourceType
    {
        Image = 10,
        Video = 20,
        File = 30
    }
    public class LinkedResources(string url, ResourceType type)
    {
        public string Url { get; private set; } = url;

        public ResourceType Type { get; private set; } = type;
    }
}