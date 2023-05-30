using Infrastructure.GameOption.LevelData;
using UnityEngine;

namespace UnityEditor
{
    [CustomEditor(typeof(EnemySpawnArea))]
    public class EnemySpawnAreaEditor : UnityEditor.Editor
    {
        [DrawGizmo(GizmoType.Active | GizmoType.Pickable)]
        public static void RenderCustomGizmo(EnemySpawnArea spawner, GizmoType gizmo)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawCube(spawner.transform.position, spawner.transform.localScale);
        }
    }
}
