using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController2 : MonoBehaviour
{
   

    public int health = 3;
    public WolfGFX wolfgfx; 
    public PlayerController player;
    public AttractorScript coin; 
    public AudioClip enemyDeadSound; 

    public TimeController timeController; 

    

    

    //bool left = true;
    //bool right = false; 
    
    // Start is called before the first frame update
    void Start()
    {
         timeController = GameObject.Find("TimeController").GetComponent<TimeController>(); 
        
    
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
            for(int i = 0; i < 2; i++){
                Vector2 dropPos = new Vector2(transform.position.x + Random.Range(-1f, 1f) , transform.position.y + Random.Range(-1f, 1f));
                Instantiate(coin, dropPos, Quaternion.identity);
            }
            timeController.DoSlowMotion2();
            Destroy(gameObject);
        }
    }


    public void reduceHealth(int damage)
    {
        this.health--; 
        //Debug.Log("here");
        wolfgfx.flash();
    }

}
