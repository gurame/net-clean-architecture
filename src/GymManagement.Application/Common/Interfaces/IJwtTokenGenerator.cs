using GymManagement.Domain.UserAggregate;

namespace GymManagement.Application.Common.Interfaces;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}