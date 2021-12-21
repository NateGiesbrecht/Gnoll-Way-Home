using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GnollController : MonoBehaviour
{
    public int health = 5;
    public GnollGFX gnollGFX; 
    public PlayerController player;
    public float knockBackDuration;
    public float knockBackForce; 
    public CoinScript coin; 

    

    //bool left = true;
    //bool right = false; 
    
    // Start is called before the first frame update
    void Start()
    {
        // knockBackDuration = 0.2f;
        // knockBackForce = 15f;
    
    }

    void FixedUpdate()
    {

    }
    // Update is called once per frame
    void Update()
    {

        if(this.health <= 0)
        {
            Instantiate(coin, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }


    public void reduceHealth(int damage)
    {
        this.health--; 
        //Debug.Log("here");
        gnollGFX.flash();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        
        switch(other.gameObject.tag)
        {

            case "Player":
            
                PlayerController player = other.gameObject.GetComponent<PlayerController>();
                Rigidbody2D playerRigid = other.gameObject.GetComponent<Rigidbody2D>(); 
                
                
                //Do stuff to player 
                player.reduceHealth(1); 
                StartCoroutine(player.knockBack(knockBackDuration, knockBackForce,this.transform));


                //ImpactPlayer();
                //ImpactBlood();
                break;
                
        }
    }
}