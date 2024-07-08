
namespace Domain.Exceptions
{
    public class NullEntityException(string type, Guid id) : Exception($"Can`t find {type}, by given id: {id}")
    {
    }
}
