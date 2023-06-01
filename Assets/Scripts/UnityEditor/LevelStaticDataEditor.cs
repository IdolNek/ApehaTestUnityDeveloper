using System.Linq;
using Infrastructure.GameOption.LevelData;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityEditor
{
    [CustomEditor(typeof(LevelStaticData))]
    public class LevelStaticDataEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var levelData = (LevelStaticData)target;
            if (GUILayout.Button("Collect"))
            {
                levelData.SetLevelKey(SceneManager.GetActiveScene().name);
                levelData.SetInitialPlayerPosition(FindObjectOfType<PlayerSpawnMarker>().transform.position);
                levelData.EnemySpawnersData = FindObjectsOfType<EnemySpawnerMarker>()
                    .Select(x => new EnemySpawnerData(x.GetComponent<UniqueId>().Id
                        , x.EnemyId, x.transform.position))
                    .ToList();
            }
            EditorUtility.SetDirty(target);
        }
    }
}