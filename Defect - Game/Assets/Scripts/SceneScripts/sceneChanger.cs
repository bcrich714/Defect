using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChanger : MonoBehaviour
{
    public void ChangeScene (string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Debug.Log("Loading Scene");
    }
    public void Exit()
    {
        Debug.Log("Quitting Scene");
        Application.Quit();
    }

    public void resetStats()
    {
        statTracker.totalDeaths = 0;
        statTracker.totalCollectibles = 0;
        statTracker.totalTime = 0;
    }
}
