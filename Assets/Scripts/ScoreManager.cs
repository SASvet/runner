
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


public class ScoreManager : MonoBehaviour
{

    public TMP_Text scoreText;


    public float scoreCount;
 
    public float pointsPerSecond;
    public bool scoreIncreasing;

    public DeathMenu DeathScreen;


    private float[] scoreHistory = new float[3];


    void Start()
    {
        if (PlayerPrefs.HasKey("HighScore0") || PlayerPrefs.HasKey("HighScore1") || PlayerPrefs.HasKey("HighScore2") || PlayerPrefs.HasKey("HighScore3") || PlayerPrefs.HasKey("HighScore4"))
        {
            for (int i = 0; i < 3; i++)
            {
                scoreHistory[i] = PlayerPrefs.GetFloat("HighScore"+i);
            }

        }

        /*Debug.Log("При запуске игры значения префа:");
        for (int i = 0; i < 3; i++)
        {
            Debug.Log("High Score " + i + ": " + PlayerPrefs.GetFloat("HighScore" + i, 0f));
        }
        */
    }


    void Update()
    {
        if (scoreIncreasing)
        {
            scoreCount += pointsPerSecond * Time.deltaTime;
        }

        scoreText.text = "Score: " + Mathf.Round(scoreCount);

    }


    public void Refresh()
    {
        Array.Sort(scoreHistory);
        if (scoreCount > scoreHistory[0])
        {
            scoreHistory[0] = scoreCount;
        }
        Array.Sort(scoreHistory, (x, y) => y.CompareTo(x));

        for (int i = 0; i < 3; i++)
        {
            PlayerPrefs.SetFloat("HighScore" + i, scoreHistory[i]);
        }

       /* Debug.Log("После обновления через экран");
        for (int i = 0; i < 3; i++)
        {
            Debug.Log("High Score " + i + ": " + PlayerPrefs.GetFloat("HighScore" + i, 0f));
        }
       */
    }
}