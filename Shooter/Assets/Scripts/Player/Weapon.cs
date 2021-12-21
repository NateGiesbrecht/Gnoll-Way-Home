using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public GameObject bullet; 
    public Transform firePoint; 
    public float fireForce;
    public AudioClip shotSound; 

    public Camera sceneCamera; 

    private Vector2 mousePosition; 

    public Transform player;

    public Rigidbody2D rb;

    void start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update(){
        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f; 
        rb.rotation = aimAngle;
        mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition); 
        transform.position = player.position; 
    }
    public void fire()
    {
        //Rotate player to follow mouse
        

        AudioSource.PlayClipAtPoint(shotSound, transform.position);
        GameObject projectile = Instantiate(bullet, firePoint.position, firePoint.rotation);
        projectile.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
    }
}
