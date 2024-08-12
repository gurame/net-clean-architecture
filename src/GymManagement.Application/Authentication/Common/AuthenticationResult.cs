using GymManagement.Domain.UserAggregate;

namespace GymManagement.Application.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token);