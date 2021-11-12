using Sold.Services.Core.Data;
using Sold.Services.Identity.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Sold.Services.Identity.Data.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task AddAsync(User user);
        Task<User> GetByIdAsync(Guid id);
    }
}