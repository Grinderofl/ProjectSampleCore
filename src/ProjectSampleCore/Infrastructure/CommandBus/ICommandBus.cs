using System.Linq;
using System.Threading.Tasks;

namespace ProjectSampleCore.Infrastructure.CommandBus
{
    public interface ICommandBus
    {
        void Send<T>(T command);
    }
}
