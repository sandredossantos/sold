using System.Threading.Tasks;

namespace Sold.Services.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}