﻿using Infrastructure.GameOption.LevelData;
using UnityEngine;

namespace UnityEditor
{
    [CustomEditor(typeof(PlayerSpawnMarker))]
    public class PlayerStartPointMarkerEditor: UnityEditor.Editor
    {
        [DrawGizmo(GizmoType.Active | GizmoType.Pickable | GizmoType.NonSelected)]
        public static void RenderCustomGizmo(PlayerSpawnMarker spawner, GizmoType gizmo)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(spawner.transform.position, 0.2f);
        }
    }
}