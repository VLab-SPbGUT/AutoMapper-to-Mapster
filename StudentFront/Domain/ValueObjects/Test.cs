
namespace Domain.ValueObjects
{
    public class Test : ValueObject
    {
        public string Name { get; private set; } = string.Empty;

        public string Url { get; private set; } = string.Empty;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
            yield return Url;
        }
    }
}
