using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro;


public class countDownController : MonoBehaviour
{

    public int countDownTime; 
    public TMP_Text countDownDisplay;
    public GameController gameController; 

    //Needed to set sprite during countdown 
    public SpriteRenderer spriteRenderer; 
    public Sprite[] skins; 
    public Animator playerAnimator; 

    public PlayerController player; 
    
    private void Start()
    {
        //Set inital loading sprite 
        string skin = PlayerPrefs.GetString("EquipedSkin", "Default");
        Debug.Log(skin);

        //pause world 
        Time.timeScale = 0; 
        StartCoroutine(CountDownToStart());
        
        
    }
    IEnumerator CountDownToStart()
    {
        while(countDownTime > 0)
        {
            countDownDisplay.text = countDownTime.ToString();
            yield return new WaitForSecondsRealtime(1f); 

            countDownTime--; 
        }

        countDownDisplay.text = "Survive!"; 

        //start game 
        //GameController.instance.BeginGame; 

        yield return new WaitForSecondsRealtime(1f);
        
        countDownDisplay.gameObject.SetActive(false); 
        //unpause world 
        Time.timeScale = 1; 

        gameController.setRunning();
        //player.setSkinAnimator();
    }
}
