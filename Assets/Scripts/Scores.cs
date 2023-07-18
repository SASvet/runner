using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Scores : MonoBehaviour
{
    public TMP_Text[] highScoreTextFields; 

    void Start()
    {
        UpdateHighScoreTextFields();
    }

    private void UpdateHighScoreTextFields()
    {
        for (int i = 0; i < highScoreTextFields.Length; i++)
        {
            float highScore = PlayerPrefs.GetFloat("HighScore" + i, 0f);
            highScoreTextFields[i].text = "Топ " + (i + 1) + ": " + Mathf.Round(highScore);
        }

      /*  Debug.Log("Это в префах:");
        for (int i = 0; i < 3; i++)
        {
            Debug.Log("High Score " + i + ": " + PlayerPrefs.GetFloat("HighScore" + i, 0f));
        }
      */
    }

    public void Back2Menu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
}
