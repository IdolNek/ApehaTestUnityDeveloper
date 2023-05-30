using System.Collections.Generic;
using UnityEngine;

namespace SpawnPool
{
    public interface IPool
    {
        List<GameObject> GameObjPool { get; }
    }
}