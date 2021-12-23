using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    
public class Bullet : MonoBehaviour
{

    public Rigidbody2D rb; 
    public ParticleSystem impactEffectWall;
    public ParticleSystem impactEffectBlood;
    public AudioClip enemyHitSound; 

    private Shake shake;
    

    public void Start()
    {
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
    }
    public void Impact()
    {
        Instantiate(impactEffectWall, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public void ImpactBlood()
    {
        Instantiate(impactEffectBlood, transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(enemyHitSound, transform.position);
        Destroy(gameObject);


    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        switch(other.gameObject.tag)
        {
            case "Wall": 
                Impact();
                break;
            case "Enemy":
                //Take Damage 
                EnemyController2 health = other.gameObject.GetComponent<EnemyController2>();
                health.reduceHealth(1); 
                shake.CamShake();
                ImpactBlood();
                break;
            case "EnemyGnoll":
                GnollController GnollHealth = other.gameObject.GetComponent<GnollController>();
                GnollHealth.reduceHealth(1); 
                shake.CamShake();
                ImpactBlood();
                break;
            case "EnemyGiant":
                GiantController GiantHealth = other.gameObject.GetComponent<GiantController>();
                GiantHealth.reduceHealth(1);
                shake.CamShake();
                ImpactBlood();

                break;
        }
    }

}
