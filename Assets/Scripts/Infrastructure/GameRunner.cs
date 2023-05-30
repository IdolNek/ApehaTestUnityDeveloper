using UnityEngine;

namespace Infrastructure
{
    public class GameRunner : MonoBehaviour
    {
        public GameLoader GameBootstrapperPrefab;

        private void Awake()
        {
            var bootstrapper = FindObjectOfType<GameLoader>();
            if (bootstrapper == null)
                Instantiate(GameBootstrapperPrefab);
        }
    }
}