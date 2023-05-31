﻿using System;
using System.Linq;
using Infrastructure.GameOption.LevelData;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace UnityEditor
{
    [CustomEditor(typeof(UniqueId))]
    public class UniqueIdEditor: Editor
    {
        private void OnEnable()
        {
            UniqueId uniqueId = (UniqueId)target;
            if (string.IsNullOrEmpty(uniqueId.Id))
                Generate(uniqueId);
            else
            {
                UniqueId[] uniqueIds = FindObjectsOfType<UniqueId>();
                if (uniqueIds.Any(other=> other != uniqueId && other.Id == uniqueId.Id)) 
                    Generate(uniqueId);
            }
        }

        private void Generate(UniqueId uniqueId)
        {
            uniqueId.Id = $"{uniqueId.gameObject.scene.name}_{Guid.NewGuid().ToString()}";
            if (!Application.isPlaying)
            {
                EditorUtility.SetDirty(uniqueId);
                EditorSceneManager.MarkSceneDirty(uniqueId.gameObject.scene);
            }
        }
    }
}