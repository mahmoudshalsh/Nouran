using System.Threading.Tasks;

namespace Nouran
{
    public interface ICommandContract<T>
    {
        Task Execute(T command);
    }
}
