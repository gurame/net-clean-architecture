using GymManagement.Domain.Common;

namespace GymManagement.Domain.SessionAggregate;
public class Reservation : Entity
{
    public Guid ParticipantId { get; }
    public Reservation(Guid participantId, Guid? id = null)
        : base(id ?? Guid.NewGuid())
    {
        ParticipantId = participantId;
    }
	private Reservation() : base(Guid.NewGuid()) { }
}