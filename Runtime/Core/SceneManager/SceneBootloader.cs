using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneBootloader : MonoBehaviour
{
    [SerializeField] private FateGames.SceneManager sceneManager;
    [SerializeField] private LevelManager levelManager;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void OnEnable()
    {
        //Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if (sceneManager.IsLevel(scene) && levelManager.AutoStart)
            levelManager.StartLevel();
    }
}
