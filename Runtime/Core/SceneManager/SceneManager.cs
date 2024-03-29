using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FateGames
{
    [CreateAssetMenu(menuName = "Fate/Manager/SceneManager")]
    public class SceneManager : ScriptableObject
    {
        [SerializeField] private int firstLevelSceneIndex = 1;
        [SerializeField] private bool loop;
        [SerializeField] private SaveDataVariable saveData;
        [SerializeField] private GameObject sceneBootloaderPrefab;
        private int levelCount { get => UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings - firstLevelSceneIndex; }
        public bool IsLevel(UnityEngine.SceneManagement.Scene scene) => scene.buildIndex >= firstLevelSceneIndex;
        private int currentLevelSceneIndex
        {
            get
            {
                if (loop)
                {
                    int loopedLevel = saveData.Value.Level % levelCount;
                    if (loopedLevel == 0) loopedLevel = levelCount;
                    return firstLevelSceneIndex - 1 + loopedLevel;
                }
                return saveData.Value.Level;
            }
        }

        public void Initialize()
        {
            Instantiate(sceneBootloaderPrefab);
        }

        public void LoadCurrentLevel(bool async = true)
        {
            LoadScene(currentLevelSceneIndex, async);
        }

        public static void LoadScene(int sceneIndex, bool async = true)
        {
            if (sceneIndex < 0 || sceneIndex >= UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings)
                throw new System.ArgumentOutOfRangeException();
            if (async)
                RoutineRunner.StartRoutine(LoadSceneAsynchronouslyRoutine(sceneIndex));
            else UnityEngine.SceneManagement.SceneManager.LoadScene(sceneIndex);
        }

        private static IEnumerator LoadSceneAsynchronouslyRoutine(int sceneIndex)
        {
            if (sceneIndex < 0 || sceneIndex >= UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings)
                throw new System.ArgumentOutOfRangeException();
            AsyncOperation operation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneIndex);
            while (!operation.isDone)
            {
                float progress = Mathf.Clamp01(operation.progress / .9f);
                yield return null;
            }
            if (operation.isDone)
            {

            }
        }


    }

}
