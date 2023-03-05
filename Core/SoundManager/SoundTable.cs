using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Fate/Sound/Sound Table")]
public class SoundTable : Table<SoundEntity>
{
#if UNITY_EDITOR
    [MenuItem("Fate/Sound/Sound Table")]
    static void SelectSoundTable()
    {
        SoundTable table = Resources.Load<SoundTable>("SoundTable");
        Selection.activeObject = table;
    }
#endif
}
