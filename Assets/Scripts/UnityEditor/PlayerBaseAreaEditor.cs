using Infrastructure.GameOption.LevelData;
using UnityEngine;

namespace UnityEditor
{
    [CustomEditor(typeof(PlayerBaseArea))]
    public class PlayerBaseAreaEditor : UnityEditor.Editor
    {
        [DrawGizmo(GizmoType.Active | GizmoType.Pickable)]
        public static void RenderCustomGizmo(PlayerBaseArea area, GizmoType gizmo)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawCube(area.transform.position, area.transform.localScale);
        }
    }
}
