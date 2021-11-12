using Sold.Services.Core.Data;
using Sold.Services.Identity.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Sold.Services.Identity.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public UserRepository(UserContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }
        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}