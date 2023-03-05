using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Fate/Manager/GameManager")]
public class GameManager : ScriptableObject
{
    [SerializeField] private int targetFrameRate = -1;
    [SerializeField] private BoolVariable paused;
    [SerializeField] private UnityEvent OnPause, OnResume;

    public void Initialize()
    {
        paused.Value = false;
        Application.targetFrameRate = targetFrameRate;
    }

    public void PauseGame()
    {
        if (paused.Value) return;
        paused.Value = true;
        OnPause.Invoke();
    }

    public void ResumeGame()
    {
        if (!paused.Value) return;
        paused.Value = false;
        OnResume.Invoke();
    }
}
