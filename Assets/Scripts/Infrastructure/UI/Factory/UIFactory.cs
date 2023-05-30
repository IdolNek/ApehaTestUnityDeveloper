using Infrastructure.Factory;
using Infrastructure.GameOption.WindowsData;
using Infrastructure.Services.Asset;
using Infrastructure.Services.StaticData;
using UI;
using UnityEngine;

namespace Infrastructure.UI.Factory
{
    class UIFactory : IUIFactory
    {
        private readonly IAssetService _asset;
        private readonly IStaticDataService _staticData;
        private const string uiRootPath = "UI/UIRoot";
        private IGameFactory _gameFactory;
        private Transform _uiRoot;

        public UIFactory(IAssetService asset, IStaticDataService staticData)
        {
            _asset = asset;
            _staticData = staticData;
        }
        public void CreateGameMenuWindow()
        {
            WindowConfig windowConfig = _staticData.ForWindow(WindowsId.GameMenu);
        }

        public void CreateUIRoot() =>
            _uiRoot = _asset.Instantiate(uiRootPath).transform;
    }
}