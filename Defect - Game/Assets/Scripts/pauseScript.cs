using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pauseScript : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenuUI;
    public GameObject HUD;
    public GameObject winMenuUI;
    public bool levelCompleted = false;
    public GameObject deathTracker;
    public TextMeshProUGUI deaths;
    public TextMeshProUGUI timer;
    public TextMeshProUGUI collectibles;

    public Text inGameTimer;
    private float finalTime;
    private float startTime;
    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        float t = Time.time - startTime;

        string minutes = ((int)t / 60).ToString();
        if (minutes.Length < 2) minutes = "0" + minutes;
        string seconds = ((int)t % 60).ToString();
        if (seconds.Length < 2) seconds = "0" + seconds;

        inGameTimer.text = minutes + ":" + seconds;

        if (Input.GetKeyDown(KeyCode.Escape) && !levelCompleted)
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        Cursor.visible = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Pause()
    {
        Cursor.visible = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void LoadMenu()
    {
        Debug.Log("LOAD MENU");
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadLevel2()
    {
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadScene("Level2Scene");
    }

    public void LoadLevel3()
    {
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadScene("Level3Scene");
    }

    public void LoadStats()
    {
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadScene("StatsScene");
    }

    public void openWinScreen()
    {
        Cursor.visible = true;
        winMenuUI.SetActive(true);
        HUD.SetActive(false);
        timer.text = timer.text + inGameTimer.text;
        deaths.text = deaths.text + (deathTracker.GetComponent<gameMasterScript>().getDeaths().ToString());
        collectibles.text = "Collectibles: " + (deathTracker.GetComponent<gameMasterScript>().getLevelCollectibles().ToString()) + "/3";
        finalTime = Time.time - startTime;
        statTracker.totalTime += finalTime;
    }


}
