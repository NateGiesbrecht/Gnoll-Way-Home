using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; 

public class UIControllerTitle : MonoBehaviour
{
    TMP_Text highscore; 
    TMP_Text coins; 
    // Start is called before the first frame update
    void Start()
    {
        highscore = GameObject.Find("HighScoreTitle").GetComponent<TMP_Text>();
        highscore.text = PlayerPrefs.GetString("Highscore", "0:00");

        coins = GameObject.Find("CoinText").GetComponent<TMP_Text>();
        coins.text = PlayerPrefs.GetInt("Coins", 0).ToString();
    }

    

    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
    }
}

