using GymManagement.Application.Common.Interfaces;
using GymManagement.Domain.AdminAggregate;
using GymManagement.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GymManagement.Infrastructure.Admins.Persistence;

internal class AdminsRepository : IAdminsRepository
{
    private readonly GymManagementDbContext _dbContext;

    public AdminsRepository(GymManagementDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task AddAdminAsync(Admin admin)
    {
        await _dbContext.Admins.AddAsync(admin);
    }
    public Task<Admin?> GetByIdAsync(Guid adminId)
    {
        return _dbContext.Admins.FirstOrDefaultAsync(a => a.Id == adminId);
    }
    public Task UpdateAsync(Admin admin)
    {
        _dbContext.Admins.Update(admin);

        return Task.CompletedTask;
    }
}