using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    private int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHearts;
    public Sprite emptyHearts; 

    public PlayerController player; 

    void Start()
    {
        
    }
    void Update()
    {
        health = player.getHealth(); 
        // if(health > numOfHearts)
        // {
        //     health = numOfHearts;
        // }
        for(int i = 0; i <hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHearts;
            }
            else
            {
                hearts[i].sprite = emptyHearts;
            }
            if( i < numOfHearts )
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
