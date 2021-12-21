using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public ParticleSystem impactEffectWall;
    public ParticleSystem impactEffectBlood;
    

    void OnTriggerEnter2D(Collider2D other)
    {
        switch(other.gameObject.tag)
        {
            case "Wall": 
                Impact();
                break;
            case "Player":
                
                PlayerController player = other.gameObject.GetComponent<PlayerController>();
                player.reduceHealth(1); 
                ImpactPlayer();
                //ImpactBlood();
                break;
                
        }
    }

    public void Impact()
    {
        Instantiate(impactEffectWall, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public void ImpactPlayer()
    {
        Instantiate(impactEffectBlood, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
