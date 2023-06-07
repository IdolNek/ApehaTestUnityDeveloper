using Infrastructure.Services.Windows;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class StartGameMenu : MonoBehaviour
    {
        [SerializeField] private Button _buttonMenu;
        private IWindowsService _windowsService;
        
        private void Awake()
        {
            _buttonMenu.onClick.AddListener(StartGame);
            Time.timeScale = 0f;
        }

        private void StartGame()
        {
            Time.timeScale = 1f;
            Destroy(gameObject);
        }
    }
}