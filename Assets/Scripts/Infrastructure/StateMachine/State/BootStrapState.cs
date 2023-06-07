using Infrastructure.Factory;
using Infrastructure.Services.Asset;
using Infrastructure.Services.ServiceLocater;
using Infrastructure.Services.StaticData;
using Infrastructure.Services.Windows;
using Infrastructure.UI.Factory;

namespace Infrastructure.StateMachine.State
{
    public class BootStrapState : IState
    {
        private const string InitialScene = "InitialScene";
        private const string GameScene = "GameScene";
        private readonly GameStateMachine _stateMachine;
        private readonly Infrastructure.SceneLoader _sceneLoader;
        private readonly AllServices _allServices;

        public BootStrapState(GameStateMachine stateMachine, Infrastructure.SceneLoader sceneLoader, AllServices allServices)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _allServices = allServices;
            RegisterServices();
        }

        public void Enter()
        {
            _sceneLoader.Load(InitialScene, onLoaded: EnterLoadLevel);
        }

        public void Exit()
        {
        }

        private void EnterLoadLevel()
        {
            _stateMachine.Enter<LoadLevelState, string>(GameScene);
        }

        private void RegisterServices()
        {
            RegisterStaticData();
            RegisterAssetService();
            RegisterUiFactory();
            RegisterWindowsService();
            RegisterGameFactory();
        }
        private void RegisterGameFactory() =>
            _allServices.RegisterSingle<IGameFactory>(new GameFactory(_allServices.Single<IAssetService>()
                , _allServices.Single<IStaticDataService>()
                , _allServices.Single<IWindowsService>()
                , _allServices.Single<IUIFactory>()));

        private void RegisterWindowsService() =>
            _allServices.RegisterSingle<IWindowsService>(new WindowsService(_allServices.Single<IUIFactory>()));

        private void RegisterUiFactory() =>
            _allServices.RegisterSingle<IUIFactory>(new UIFactory(_allServices.Single<IAssetService>()
                , _allServices.Single<IStaticDataService>()));

        private void RegisterAssetService() =>
            _allServices.RegisterSingle<IAssetService>(new AssetService());

        private void RegisterStaticData()
        {
            IStaticDataService staticData = new StaticDataService();
            staticData.LoadStaticData();
            _allServices.RegisterSingle<IStaticDataService>(staticData);
        }
    }
}