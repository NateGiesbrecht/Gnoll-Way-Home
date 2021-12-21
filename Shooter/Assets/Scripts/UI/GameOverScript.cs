using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public TMP_Text score;
    TMP_Text highscore; 
    public TMP_Text NewHighScore;
    public Timer timer;
    
    
    public void Start()
    {
        //NewHighScore.gameObject.SetActive(false);
    }

    public void Setup(int inputScore)
    {
        gameObject.SetActive(true);
        //score = GameObject.Find("Score").GetComponent<TMP_Text>();
        //highscore = GameObject.Find("Highscore").GetComponent<TMP_Text>();
        //NewHighScore = GameObject.Find("NewHighScore").GetComponent<TMP_Text>();
        //NewHighScore.gameObject.SetActive(false); //Default to not showing 
        Debug.Log(timer.timerText.text);
        score.text = "You survived for " + timer.timerText.text; 

        //Check for new highScore 
        string currHighScore = PlayerPrefs.GetString("Highscore", "0:00");
        int compare = string.Compare(timer.timerText.text , currHighScore);  //Compare scores 
        //Debug.Log("Curr: " + currHighScore + " New: " + timer.timerText.text + " Compare: " + compare);
        if(compare == 1)
        {
            PlayerPrefs.SetString("Highscore", timer.timerText.text);
            NewHighScore.gameObject.SetActive(true);
        }

        highscore.text = PlayerPrefs.GetString("Highscore", "00:00");
    }

    public void Quit()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Retry()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
