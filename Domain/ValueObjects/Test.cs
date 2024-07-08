
namespace Domain.ValueObjects
{
    public class Test : ValueObject
    {
        public string Name { get;  set; } = string.Empty;

        public string Url { get;  set; } = string.Empty;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
            yield return Url;
        }
    }
}
