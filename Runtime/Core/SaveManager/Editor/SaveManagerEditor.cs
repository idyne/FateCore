using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.AnimatedValues;

[CustomEditor(typeof(SaveManager))]
public class SaveManagerEditor : Editor
{
    private AnimBool overrideSave, autoSave;
    private SaveManager saveManager;

    private void OnEnable()
    {
        saveManager = target as SaveManager;
        overrideSave = new();
        overrideSave.value = saveManager.OverrideSave;
        overrideSave.valueChanged.AddListener(Repaint);
        autoSave = new();
        autoSave.value = saveManager.AutoSave;
        autoSave.valueChanged.AddListener(Repaint);
    }
    public override void OnInspectorGUI()
    {
        overrideSave.target = EditorGUILayout.ToggleLeft("Override Save", saveManager.OverrideSave);
        saveManager.OverrideSave = overrideSave.target;
        EditorGUI.BeginDisabledGroup(overrideSave.target);
        EditorGUI.indentLevel++;
        saveManager.OverrideSaveData = EditorGUILayout.ObjectField("Override Save Data", saveManager.OverrideSaveData, typeof(SaveDataVariable), false) as SaveDataVariable;
        EditorGUI.indentLevel--;
        autoSave.target = EditorGUILayout.ToggleLeft("Auto Save", saveManager.AutoSave);
        saveManager.AutoSave = autoSave.target;

        EditorGUI.indentLevel++;
        saveManager.AutoSavePeriod = EditorGUILayout.FloatField("Auto Save Period", saveManager.AutoSavePeriod);
        EditorGUI.indentLevel--;


        EditorGUI.EndDisabledGroup();
        saveManager.SaveData = EditorGUILayout.ObjectField("Save Data", saveManager.SaveData, typeof(SaveDataVariable), false) as SaveDataVariable;

    }
}
