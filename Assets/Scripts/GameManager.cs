using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{

    public TMP_Text coinsText;

    public Transform platformGenerator;
    private Vector3 platformStartPoint;

    public PlayerController player;
    private Vector3 playerStartPoint;

    private PlatformDestroyer[] platformList;

    private ScoreManager scoreManager;

    public Shield shieldTimer;

    public DeathMenu DeathScreen;

    // Start is called before the first frame update
    void Start()
    {
        platformStartPoint = platformGenerator.position;
        playerStartPoint = player.transform.position;
        scoreManager = FindObjectOfType<ScoreManager>();
    }


    void Update()
    {
        
    }

    public void RestartGame()
    {
        scoreManager.scoreIncreasing = false;
        player.gameObject.SetActive(false);
        DeathScreen.gameObject.SetActive(true);
    }


    public void Reset()
    {
        platformList = FindObjectsOfType<PlatformDestroyer>();
        for (int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);
        }
        player.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        player.gameObject.SetActive(true);

        scoreManager.scoreCount = 0;
        scoreManager.scoreIncreasing = true;
        player.health = 1;
        player.coins = 0;
        coinsText.text = player.coins.ToString();

        if (shieldTimer.gameObject.activeSelf)
        {
            shieldTimer.gameObject.SetActive(false);
            shieldTimer.isCooldown = false;
        }
        DeathScreen.gameObject.SetActive(false);

    }

}
