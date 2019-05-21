using System.Threading.Tasks;
using KP.BackEnd.Core.Repositories;

namespace KP.BackEnd.Core
{
    public interface IUnitOfWork
    {
        ICardRepository Cards { get; }
        Task Complete();
    }
}