using Infrastructure.Factory;
using Infrastructure.Services;

namespace Infrastructure.UI.Factory
{
    public interface IUIFactory : IService
    {
        void CreateGameMenuWindow();
        void CreateUIRoot();
    }
}