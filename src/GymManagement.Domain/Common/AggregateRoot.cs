
namespace GymManagement.Domain.Common;
public abstract class AggregateRoot(Guid id) : Entity(id)
{
	protected readonly List<IDomainEvent> _domainEvents = [];
	public List<IDomainEvent> PopDomainEvents()
	{
		var copy = _domainEvents.ToList();
		_domainEvents.Clear();
		return copy;
	}
}