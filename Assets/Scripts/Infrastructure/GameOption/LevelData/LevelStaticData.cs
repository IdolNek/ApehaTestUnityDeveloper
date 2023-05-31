﻿using UnityEngine;

namespace Infrastructure.GameOption.LevelData
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "StaticData/Level")]
    public class LevelStaticData : ScriptableObject
    {
        [SerializeField] private string _levelKey;
        [SerializeField] private Vector3 _initialHeroPosition;
        public string LevelKey => _levelKey;
        public Vector3 InitialHeroPosition => _initialHeroPosition;
        public void SetInitialPlayerPosition(Vector3 position) => 
            _initialHeroPosition = position;

        public void SetLevelKey(string name) => 
            _levelKey = name;
    }
}