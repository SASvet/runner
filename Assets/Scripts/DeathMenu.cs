using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
  
    public void RestartGame()
    {
        FindObjectOfType<GameManager>().Reset();
    }

    public void Back2Menu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }

    public void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }


    private void OnEnable()
    {
        FindObjectOfType<ScoreManager>().Refresh();
    }
}
