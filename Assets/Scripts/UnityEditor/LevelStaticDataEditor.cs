using Infrastructure.GameOption.LevelData;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityEditor
{
    [CustomEditor(typeof(LevelStaticData))]
    public class LevelStaticDataEditor : UnityEditor.Editor
    {
        private const string initialPoint = "StartPlayerPoint";

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var levelData = (LevelStaticData)target;
            if (GUILayout.Button("Collect"))
            {
                levelData.SetLevelKey(SceneManager.GetActiveScene().name);
                levelData.SetInitialPlayerPosition(FindObjectOfType<PlayerSpawnMarker>().gameObject.transform.position);
            }
            EditorUtility.SetDirty(target);
        }
    }
}