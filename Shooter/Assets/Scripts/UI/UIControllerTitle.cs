using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; 

public class UIControllerTitle : MonoBehaviour
{
    TMP_Text highscore; 
    TMP_Text coins; 
    public Animator animator; 
    public AnimatorOverrideController redAnimController;
    public AnimatorOverrideController blueAnimController;
    public AnimatorOverrideController purpleAnimController;
    // Start is called before the first frame update
    void Start()
    {
        highscore = GameObject.Find("HighScoreTitle").GetComponent<TMP_Text>();
        highscore.text = PlayerPrefs.GetString("Highscore", "0:00");

        coins = GameObject.Find("CoinText").GetComponent<TMP_Text>();
        coins.text = PlayerPrefs.GetInt("Coins", 0).ToString();

        //Set Default skin if none is currently selected 
        PlayerPrefs.GetString("EquipedSkin", "Default");

        string skin = PlayerPrefs.GetString("EquipedSkin", "Default");
        
        //Set skin during countdown 
        
        switch(skin)
        {
            case "Default":
                //spriteRenderer.sprite = skins[0];
                break;
            case "Red":
                //spriteRenderer.sprite = skins[1];
                RedSkin();
                break;
            case "Blue": 
                //spriteRenderer.sprite = skins[2];
                BlueSkin();
                break;
            case "Purple":
                //spriteRenderer.sprite = skins[3];
                PurpleSkin();
                break;
        }
    }

    

    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Shop()
    {
        SceneManager.LoadScene("Shop");
    }

     public void RedSkin()
    {
        animator.runtimeAnimatorController = redAnimController;
    }
     public void PurpleSkin()
    {
        animator.runtimeAnimatorController = purpleAnimController;
    }
    public void BlueSkin()
    {
        animator.runtimeAnimatorController = blueAnimController;
    }

}

