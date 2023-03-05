using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Fate/Manager/LevelManager")]
public class LevelManager : ScriptableObject
{
    [SerializeField] private bool autoStart = false;
    [SerializeField] private UnityEvent OnLevelStarted, OnLevelFinished;

    public bool AutoStart { get => autoStart; }

    public void StartLevel()
    {
        OnLevelStarted.Invoke();
    }

    public void FinishLevel(bool success)
    {
        OnLevelFinished.Invoke();
    }
}
