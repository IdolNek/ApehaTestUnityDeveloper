using Infrastructure.GameOption.LevelData;
using UnityEngine;

namespace UnityEditor
{
    [CustomEditor(typeof(EnemySpawnerMarker))]
    public class EnemySpawnerMarkerEditor: Editor
    {
        [DrawGizmo(GizmoType.Active | GizmoType.Pickable | GizmoType.NonSelected)]
        public static void RenderCustomGizmo(EnemySpawnerMarker spawnerMarker, GizmoType gizmo)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(spawnerMarker.transform.position, 0.2f);
        }
    }
}