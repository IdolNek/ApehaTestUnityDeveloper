using Infrastructure.GameOption.EnemyData;
using Infrastructure.GameOption.LevelData;
using Infrastructure.GameOption.Player;
using Infrastructure.GameOption.WindowsData;

namespace Infrastructure.Services.StaticData
{
    public interface IStaticDataService : IService
    {
        PlayerStaticData PlayerConfig { get; }

        void LoadStaticData();
        EnemyStaticData ForEnemy(EnemyTypeId typeId);
        LevelStaticData ForLevel(string levelKey);
        WindowConfig ForWindow(WindowsId chooseAbility);
    }
}