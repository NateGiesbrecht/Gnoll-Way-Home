using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public GameObject bullet; 
    public GameObject grenade; 
    public Transform firePoint; 
    public float fireForce;
    public AudioClip shotSound; 

    public Camera sceneCamera; 

    private Vector2 mousePosition; 

    public Transform player;

    public Rigidbody2D rb;


    private Vector2 aimDirection;

    public Animator gunAnimator; 

    void start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update(){
        aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f; 

        rb.rotation = aimAngle;
        mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition); 
        transform.position = player.position; 
        //transform.position.x = 

        if(aimAngle < 0 && aimAngle> -180){
            gunAnimator.SetBool("Right", true);
            gunAnimator.SetBool("Left", false);

        }
        else
        {
            gunAnimator.SetBool("Right", false);
            gunAnimator.SetBool("Left", true);
        }

        
    }
    public void fire()
    {
        //Rotate player to follow mouse
        

        AudioSource.PlayClipAtPoint(shotSound, transform.position);
        GameObject projectile = Instantiate(bullet, firePoint.position, firePoint.rotation);
        projectile.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
    }

    public void ThrowGrenade()
    {
        GameObject projectile = Instantiate(grenade, firePoint.position, firePoint.rotation);
        //projectile.GetComponent<Rigidbody2D>().MoveTowards(transform.position, aimDirection, grenadeSpeed * Time.deltaTime);
    }
}
