using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    public GameOverScript gameOverScript; 
    public PlayerController player; 
    private bool paused = false;
    private bool running = false; 
    public TMP_Text pause;
    private bool coinsUpdated = false; 
    // Start is called before the first frame update
    void Start()
    {
        running = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(paused)
        {
            Time.timeScale = 0;
        }else if (running){
            Time.timeScale = 1;
        }
        if(Input.GetKeyDown(KeyCode.Escape) && running)
        {
            
           //TMP_Text pause = GameObject.Find("Pause").GetComponent<TMP_Text>();
           paused = !paused; 
           switch(paused){
               case true: 
                pause.gameObject.SetActive(true);
                break;
               case false:
                pause.gameObject.SetActive(false);
                break;
           } 
           
        }

        if(player.isDead)
        {
            gameOverScript.Setup(1);

            if(!coinsUpdated){
                // Add coins to total 
                int currCoins = PlayerPrefs.GetInt("Coins", 0);
                currCoins += player.getCoins();
                
                PlayerPrefs.SetInt("Coins", currCoins);
                coinsUpdated = true;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        
    }

    public void setRunning()
    {
        running = true; 
    }
}
