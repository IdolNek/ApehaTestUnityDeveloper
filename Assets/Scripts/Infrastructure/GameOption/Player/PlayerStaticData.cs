using UnityEngine;

namespace Infrastructure.GameOption.Player
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "StaticData/Player")]
    public class PlayerStaticData : ScriptableObject
    {
        [Range(1, 100)]
        public int Hp;
        public GameObject PlayerPrefab;
    }
}
