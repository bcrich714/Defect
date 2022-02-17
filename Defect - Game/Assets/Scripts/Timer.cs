using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public Text timerText;
    private float startTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time - startTime;

        string minutes = ((int) t / 60).ToString();
        if (minutes.Length < 2) minutes = "0" + minutes;
        string seconds = ((int) t % 60).ToString();
        if (seconds.Length < 2) seconds = "0" + seconds;

        timerText.text = minutes + ":" + seconds;
    }

    string getTime()
    {
        return timerText.text;
    }
}
