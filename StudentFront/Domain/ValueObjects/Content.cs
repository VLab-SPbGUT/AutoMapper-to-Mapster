namespace Domain.ValueObjects
{
    public sealed class Content : ValueObject
    {
        public ContentType ContentType { get; set; }

        public bool ReadOnly { get; set; }

        public string Url { get; set; } = string.Empty;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return ContentType;
            yield return ReadOnly;
            yield return Url;
        }
    }
}
