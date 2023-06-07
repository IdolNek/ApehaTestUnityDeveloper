using Infrastructure.Factory;
using Infrastructure.GameOption.WindowsData;
using Infrastructure.Services.Asset;
using Infrastructure.Services.StaticData;
using UnityEngine;

namespace Infrastructure.UI.Factory
{
    class UIFactory : IUIFactory
    {
        private const string UIRootPath = "UI/UIRoot";
        
        private readonly IAssetService _asset;
        private readonly IStaticDataService _staticData;
        
        private IGameFactory _gameFactory;
        private Transform _uiRoot;

        public UIFactory(IAssetService asset, IStaticDataService staticData)
        {
            _asset = asset;
            _staticData = staticData;
        }
        
        public void CreateUIRoot() =>
            _uiRoot = _asset.Instantiate(UIRootPath).transform;

        public void CreateStartGameMenu()
        {
            WindowConfig windowsConfig = _staticData.ForWindow(WindowsId.StartGameMenu);
            GameObject window = Object.Instantiate(windowsConfig.WindowPrefab, _uiRoot);
        }

        public void CreateGameOverMenu()
        {
            WindowConfig windowsConfig = _staticData.ForWindow(WindowsId.GameOverMenu);
            GameObject window = Object.Instantiate(windowsConfig.WindowPrefab, _uiRoot);
        }
    }
}