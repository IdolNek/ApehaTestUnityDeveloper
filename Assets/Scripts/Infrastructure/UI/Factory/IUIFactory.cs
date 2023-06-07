using Infrastructure.Factory;
using Infrastructure.Services;

namespace Infrastructure.UI.Factory
{
    public interface IUIFactory : IService
    {
        void CreateUIRoot();
        void CreateStartGameMenu();
        void CreateGameOverMenu();
    }
}