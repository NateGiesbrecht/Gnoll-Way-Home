using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRateUp : MonoBehaviour
{
    [SerializeField] private GameObject FloatingText;
    public GameObject pickupEffect;
    public float fireRateIncrease = 0.03f;  

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Pickup(other);
        }
    }

    void Pickup(Collider2D other)
    {
        
        //spawn cool effect
        Instantiate(pickupEffect, transform.position, transform.rotation);
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        player.increaseFireRate(fireRateIncrease);
        //apply effect 

        ShowFloatingText("Fire Rate Increased");
        //remove powerup 
       Destroy(gameObject);
    }

    void ShowFloatingText(string text)
    {
        GameObject prefab = Instantiate(FloatingText, transform.position, Quaternion.identity);
        prefab.GetComponentInChildren<TextMesh>().text = text;
    }
}
