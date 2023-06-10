using Infrastructure.GameOption.LevelData;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(EnemySpawnerMarker))]
    public class EnemySpawnerMarkerEditor: UnityEditor.Editor
    {
        [DrawGizmo(GizmoType.Active | GizmoType.Pickable | GizmoType.NonSelected)]
        public static void RenderCustomGizmo(EnemySpawnerMarker spawnerMarker, GizmoType gizmo)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(spawnerMarker.transform.position, 0.2f);
        }
    }
}