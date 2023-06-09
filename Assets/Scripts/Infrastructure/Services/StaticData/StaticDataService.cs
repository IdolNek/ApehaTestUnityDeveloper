﻿using System.Collections.Generic;
using System.Linq;
using Infrastructure.GameOption.EnemyData;
using Infrastructure.GameOption.LevelData;
using Infrastructure.GameOption.Player;
using Infrastructure.GameOption.WindowsData;
using UnityEngine;

namespace Infrastructure.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private const string staticDataEnemies = "GameOption/EnemyData";
        private const string staticDataLevels = "GameOption/LevelData";
        private const string staticDataWindows = "GameOption/WindowsData/WindowsData";
        private const string staticDataPlayer = "GameOption/PlayerData/PlayerData";
        private Dictionary<EnemyTypeId, EnemyStaticData> _enemys;
        private Dictionary<string, LevelStaticData> _levels;
        private Dictionary<WindowsId, WindowConfig> _windowConfigs;
        private PlayerStaticData _playerConfig;

        public PlayerStaticData PlayerConfig => _playerConfig; 

        public void LoadStaticData()
        {
            _enemys = Resources.LoadAll<EnemyStaticData>(staticDataEnemies)
                .ToDictionary(x => x.EnemyTypeId, x => x);
            _levels = Resources
                .LoadAll<LevelStaticData>(staticDataLevels)
                .ToDictionary(x => x.LevelKey, x => x);
            _windowConfigs = Resources
                .Load<WindowsStaticData>(staticDataWindows)
                .Configs
                .ToDictionary(x => x.WindowsId, x => x);
            _playerConfig = Resources.Load<PlayerStaticData>(staticDataPlayer);
        }

        public EnemyStaticData ForEnemy(EnemyTypeId typeId) =>
            _enemys.TryGetValue(typeId, out EnemyStaticData staticData)
                ? staticData
                : null;

        public LevelStaticData ForLevel(string levelKey) =>
            _levels.TryGetValue(levelKey, out LevelStaticData staticData)
                ? staticData
                : null;

        public WindowConfig ForWindow(WindowsId windowsId) =>
            _windowConfigs.TryGetValue(windowsId, out WindowConfig windowConfig)
                ? windowConfig
                : null;
    }
}