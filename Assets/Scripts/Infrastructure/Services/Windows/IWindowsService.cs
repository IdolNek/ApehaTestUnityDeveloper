using Infrastructure.GameOption.WindowsData;

namespace Infrastructure.Services.Windows
{
    public interface IWindowsService : IService
    {
        void Open(WindowsId windowsId);
    }
}