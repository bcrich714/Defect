using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loadFinalStats : MonoBehaviour
{
    public TextMeshProUGUI deaths;
    public TextMeshProUGUI timer;
    public TextMeshProUGUI collectibles;
    // Start is called before the first frame update
    void Start()
    {
        int deathsCount = statTracker.totalDeaths;
        int collectiblesCount = statTracker.totalCollectibles;
        float timeCount = statTracker.totalTime;

        deaths.text += deathsCount.ToString();
        collectibles.text += collectiblesCount.ToString() + "/9";

        string minutes = ((int)timeCount / 60).ToString();
        if (minutes.Length < 2) minutes = "0" + minutes;
        string seconds = ((int)timeCount % 60).ToString();
        if (seconds.Length < 2) seconds = "0" + seconds;
        timer.text += minutes + ":" + seconds;
    }
}
