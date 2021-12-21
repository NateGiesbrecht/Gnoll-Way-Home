using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUp : MonoBehaviour
{
    [SerializeField] private GameObject FloatingText;
    public GameObject pickupEffect;
    public int healthIncrease = 1;  

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            
            PlayerController player = other.gameObject.GetComponent<PlayerController>();
            if(player.health < player.maxHealth)
            {
                Pickup(other);
            }
        }
    }

    void Pickup(Collider2D other)
    {
        
        //spawn cool effect
        Instantiate(pickupEffect, transform.position, transform.rotation);
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        player.restoreHealth(healthIncrease);
        //apply effect 

        ShowFloatingText("Health Restored");
        //remove powerup 
        Destroy(gameObject);
    }

    void ShowFloatingText(string text)
    {
        GameObject prefab = Instantiate(FloatingText, transform.position, Quaternion.identity);
        prefab.GetComponentInChildren<TextMesh>().text = text;
    }
}
