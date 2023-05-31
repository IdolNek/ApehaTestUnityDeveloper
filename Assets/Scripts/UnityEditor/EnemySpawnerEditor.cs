using Infrastructure.GameOption.LevelData;
using UnityEngine;

namespace UnityEditor
{
    [CustomEditor(typeof(EnemySpawner))]
    public class EnemySpawnerEditor: Editor
    {
        [DrawGizmo(GizmoType.Active | GizmoType.Pickable | GizmoType.NonSelected)]
        public static void RenderCustomGizmo(EnemySpawner spawner, GizmoType gizmo)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(spawner.transform.position, 0.2f);
        }
    }
}