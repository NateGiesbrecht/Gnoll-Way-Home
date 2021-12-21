using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public GameObject enemyBullet; 
    public Transform firePoint; 
    public float fireForce;
    
    public Rigidbody2D rb;

    private float timeBetweenShots;
    public float startTimeBetweenShots; 

    public Transform player;
    public Transform enemy;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform; 
        
        timeBetweenShots = startTimeBetweenShots;
    }

    void FixedUpdate()
    {
        if(timeBetweenShots <= 0)
        {
            //Instantiate(enemyBullet, transform.position, Quaternion.identity);
            GameObject projectile = Instantiate(enemyBullet, firePoint.position, firePoint.rotation);
            projectile.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
            timeBetweenShots = startTimeBetweenShots; 
        }
        else
        {
            timeBetweenShots -= Time.fixedDeltaTime;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(player == null) 
        {
            Destroy(gameObject);
            return; 
        }
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle; 
        transform.position = enemy.position; 
    }
}
