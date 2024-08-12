using ErrorOr;
using GymManagement.Domain.Common;
using GymManagement.Domain.Common.Interfaces;
using GymManagement.Domain.Common.ValueObjects;
using GymManagement.Domain.ParticipantAggregate;

namespace GymManagement.Domain.SessionAggregate;

public class Session : AggregateRoot
{
    private readonly Guid _trainerId;
    private readonly List<Reservation> _reservations = [];
    private readonly int _maxParticipants;
    public DateOnly Date { get; }
    public TimeRange Time { get; }

    public Session(
        DateOnly date,
        TimeRange time,
        int maxParticipants,
        Guid trainerId,
        Guid? id = null)
            : base(id ?? Guid.NewGuid())
    {
        Date = date;
        Time = time;
        _maxParticipants = maxParticipants;
        _trainerId = trainerId;
    }
	private Session() : base(Guid.NewGuid()) { }

    public ErrorOr<Success> CancelReservation(Participant participant, IDateTimeProvider dateTimeProvider)
    {
        if (IsTooCloseToSession(dateTimeProvider.UtcNow))
        {
            return SessionErrors.CannotCancelReservationTooCloseToSession;
        }

        var reservation = _reservations.Find(reservation => reservation.ParticipantId == participant.Id);
        if (reservation is null)
        {
            return Error.NotFound(description: "Participant not found");
        }

        _reservations.Remove(reservation);

        return Result.Success;
    }

    private bool IsTooCloseToSession(DateTime utcNow)
    {
        const int MinHours = 24;

        return (Date.ToDateTime(Time.Start) - utcNow).TotalHours < MinHours;
    }

    public ErrorOr<Success> ReserveSpot(Participant participant)
    {
        if (_reservations.Count >= _maxParticipants)
        {
            return SessionErrors.CannotHaveMoreReservationsThanParticipants;
        }

        if (_reservations.Any(reservation => reservation.ParticipantId == participant.Id))
        {
            return Error.Conflict(description: "Participants cannot reserve twice to the same session");
        }

        var reservation = new Reservation(participant.Id);

        _reservations.Add(reservation);

        return Result.Success;
    }
}