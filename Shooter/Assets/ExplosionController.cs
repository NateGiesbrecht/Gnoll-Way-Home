using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{

    private Vector2 center;
    public float radius = 5;
    // Start is called before the first frame update
    void Start()
    {
        center = transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] enemyHit = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach ( Collider2D col in enemyHit)
        {
            switch(col.gameObject.tag)
            {
                case "Enemy":
                    //Take Damage 
                    EnemyController2 health = col.gameObject.GetComponent<EnemyController2>();
                    health.reduceHealthGrenade(3); 
                    
                    break;
                case "EnemyGnoll":
                    GnollController GnollHealth = col.gameObject.GetComponent<GnollController>();
                    GnollHealth.reduceHealthGrenade(3); 
                    
                    break;
                case "EnemyGiant":
                    GiantController GiantHealth = col.gameObject.GetComponent<GiantController>();
                    GiantHealth.reduceHealthGrenade(3);
                    

                    break;
            }
        }
    }

    public void DestroyIt()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawSphere(transform.position, radius);
    }
}
