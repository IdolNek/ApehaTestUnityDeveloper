using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.GameOption.WindowsData
{
    [CreateAssetMenu(fileName = "WindowsData", menuName = "StaticData/Windows")]
    public class WindowsStaticData : ScriptableObject
    {
        public List<WindowConfig> Configs;
    }
}