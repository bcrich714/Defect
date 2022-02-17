using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class gameMasterScript : MonoBehaviour
{
    public static gameMasterScript instance;

    public Transform startPoint, checkpoint;
    public GameObject basePlayerPrefab, sidePlayerPrefab;
    public int spawnDelay = 1; 
    int numOfAlivePlayers = 2;
    public AudioSource deathSound, switchSound;
    public bool basePlayerActive = true;
    bool sidePlayerObtained = false;
    bool atCheckpoint = false;
    public Text deathCounter;
    private int deaths = 0;
    private int levelCollectibles = 0;
    public GameObject[] collectibleHUD;
    public Sprite collectibleImg;



    private void Awake()
    {
        instance = this;
        GameObject player = Instantiate(basePlayerPrefab, startPoint.position, Quaternion.identity);
        player.GetComponent<playerMovementScript>().setIsActive(basePlayerActive);
        Cursor.visible = false;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && numOfAlivePlayers == 2 && sidePlayerObtained)
        {
            switchSound.Play();
            switchActivePlayer();
        }
    }



    public IEnumerator Respawn(string charType)
    {
        deathSound.Play();
        deaths++;
        deathCounter.text = deaths.ToString();
        Transform respawn;
        if (atCheckpoint) respawn = checkpoint;
        else respawn = startPoint;

        if (!sidePlayerObtained)
        {
            yield return new WaitForSeconds(spawnDelay);
            GameObject player = Instantiate(basePlayerPrefab, respawn.position, Quaternion.identity);
        }
        else
        {
            numOfAlivePlayers--;
            if (charType.Equals("main"))
            {
                if (basePlayerActive && numOfAlivePlayers != 0)
                {
                    switchActivePlayer();
                }
                yield return new WaitForSeconds(spawnDelay);
                GameObject player = Instantiate(basePlayerPrefab, respawn.position, Quaternion.identity);
                player.GetComponent<playerMovementScript>().setIsActive(basePlayerActive);
                if (basePlayerActive)
                {
                    player.GetComponent<playerMovementScript>().isActive = true;
                    player.GetComponent<Animator>().SetBool("isMoving", true);
                    GameObject[] cam = GameObject.FindGameObjectsWithTag("MainCamera");
                    cam[0].GetComponent<cameraFollow>().target = player.GetComponent<Transform>();
                }
                else
                {
                    player.GetComponent<playerMovementScript>().isActive = false;
                    player.GetComponent<Animator>().SetBool("isMoving", false);
                }
                numOfAlivePlayers++;
                yield break;
            }
            else
            {
                if (!basePlayerActive && numOfAlivePlayers != 0)
                {
                    switchActivePlayer();
                }
                yield return new WaitForSeconds(spawnDelay);
                GameObject sidePlayer = Instantiate(sidePlayerPrefab, respawn.position, Quaternion.identity);
                sidePlayer.GetComponent<playerMovementScript>().setIsActive(!basePlayerActive);
                if (!basePlayerActive)
                {
                    sidePlayer.GetComponent<playerMovementScript>().isActive = true;
                    sidePlayer.GetComponent<Animator>().SetBool("isMoving", true);
                    GameObject[] cam = GameObject.FindGameObjectsWithTag("MainCamera");
                    cam[0].GetComponent<cameraFollow>().target = sidePlayer.GetComponent<Transform>();
                }
                else
                {
                    sidePlayer.GetComponent<playerMovementScript>().isActive = false;
                    sidePlayer.GetComponent<Animator>().SetBool("isMoving", false);
                }
                numOfAlivePlayers++;
                yield break;
            }
        }
    }

    public void switchActivePlayer()
    {
        if (numOfAlivePlayers == 0) return;
        
        GameObject[] mainPlayer = GameObject.FindGameObjectsWithTag("Player");
        GameObject[] sidePlayer = GameObject.FindGameObjectsWithTag("SidePlayer");

        if (basePlayerActive)
        {
            mainPlayer[0].GetComponent<playerMovementScript>().isActive = false;
            mainPlayer[0].GetComponent<playerMovementScript>().CloseInteractIcon();
            mainPlayer[0].GetComponent<Animator>().SetBool("isMoving", false);

            sidePlayer[0].GetComponent<playerMovementScript>().isActive = true;
            sidePlayer[0].GetComponent<playerMovementScript>().OpenInteractIcon();
            sidePlayer[0].GetComponent<Animator>().SetBool("isMoving", true);
            GameObject[] cam = GameObject.FindGameObjectsWithTag("MainCamera");
            cam[0].GetComponent<cameraFollow>().target = sidePlayer[0].GetComponent<Transform>();

        }
        else
        {
            mainPlayer[0].GetComponent<playerMovementScript>().isActive = true;
            mainPlayer[0].GetComponent<playerMovementScript>().OpenInteractIcon();
            mainPlayer[0].GetComponent<Animator>().SetBool("isMoving", true);
            sidePlayer[0].GetComponent<playerMovementScript>().isActive = false;
            sidePlayer[0].GetComponent<playerMovementScript>().CloseInteractIcon();
            sidePlayer[0].GetComponent<Animator>().SetBool("isMoving", false);
            GameObject[] cam = GameObject.FindGameObjectsWithTag("MainCamera");
            cam[0].GetComponent<cameraFollow>().target = mainPlayer[0].GetComponent<Transform>();
        }
        
        basePlayerActive = !basePlayerActive;
    }

    public void createSecondPlayer()
    {
        sidePlayerObtained = true;
        GameObject sidePlayer = Instantiate(sidePlayerPrefab, checkpoint.position, Quaternion.identity);
        sidePlayer.GetComponent<playerMovementScript>().setIsActive(!basePlayerActive);
        atCheckpoint = true;
    }

    public int getDeaths()
    {
        return deaths;
    }

    public int getLevelCollectibles()
    {
        return levelCollectibles;
    }

    public void gotCollectible(int id)
    {
        levelCollectibles++;
        collectibleHUD[id-1].GetComponent<Image>().sprite = collectibleImg;
    }
}
