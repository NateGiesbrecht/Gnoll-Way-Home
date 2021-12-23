using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public GameOverScript gameOverScript; 
    public PlayerController player; 
    public bool paused = false;
    private bool running = false; 
    public GameObject pause;
    private bool coinsUpdated = false; 
    private bool playerSet = false;
    public int mapToSpawn;
    
    // Start is called before the first frame update
    void Start()
    {
        running = false;
        mapToSpawn = (int)Random.Range(0,3);
    }

    // Update is called once per frame
    void Update()
    {
        if(!playerSet)
        {
            Vector2 temp;
            switch(mapToSpawn){
                
                case 0:
                    temp = new Vector2(384.2f, -29.4f); 
                    player.transform.position = temp;
                    playerSet = true;
                    break;
                case 1:
                    temp = new Vector2(110.5f, -8.9f);
                    player.transform.position = temp;
                    playerSet = true;
                    break;
                case 2:
                    temp = new Vector2(-2.6f, -4.3f);
                    player.transform.position = temp;
                    playerSet = true;
                    break;
            }
        }
        // if(paused)
        // {
        //     Time.timeScale = 0;
        // }else if (running){
        //     Time.timeScale = 1;
        // }
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
                Time.timeScale = 1;
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

    public void setNotRunning()
    {
        running = false; 
    }
}
