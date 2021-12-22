using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantController : MonoBehaviour
{
    public int health = 10;
    public GiantGFX giantgfx; 
    public PlayerController player;
    public CoinScript coin;
    public AudioClip enemyDeadSound; 

    


    //bool left = true;
    //bool right = false; 
    
    // Start is called before the first frame update
    void Start()
    {


    
    }

    void FixedUpdate()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if(this.health <= 0)
        {
            AudioSource.PlayClipAtPoint(enemyDeadSound, transform.position);
            Instantiate(coin, transform.position, Quaternion.identity);
            Destroy(gameObject);
            
        }
    }


    public void reduceHealth(int damage)
    {
        this.health--; 
        giantgfx.flash();
    }

    
}
