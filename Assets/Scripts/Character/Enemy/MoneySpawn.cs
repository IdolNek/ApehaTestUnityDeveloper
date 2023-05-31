using Infrastructure.Factory;
using MoneyBank;
using UnityEngine;

namespace Character.Enemy
{
    public class MoneySpawn : MonoBehaviour
    {
        private IGameFactory _gameFactory;
        private int _moneyCount;

        public void Construct(IGameFactory gameFactory) => 
            _gameFactory = gameFactory;

        public void Initialize(int moneyCount) => 
            _moneyCount = moneyCount;

        // private void OnEnable() =>
        //     _death.CharacterDied += OnCharacterDied;
        //
        // private void OnCharacterDied()
        // {
        //     var money = _gameFactory.CreateMoney(transform.position);
        //     money.GetComponent<Money>().SetCount(_moneyCount);
        // }
        //
        // private void OnDisable() =>
        //     _death.CharacterDied -= OnCharacterDied;

    }
}