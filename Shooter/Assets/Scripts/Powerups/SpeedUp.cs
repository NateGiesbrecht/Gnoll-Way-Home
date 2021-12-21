using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeedUp : MonoBehaviour
{
    [SerializeField] private GameObject FloatingText; 
    public GameObject pickupEffect;
    public float speedIncrease = 0.5f; 

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
        player.increaseSpeed(speedIncrease);
        //apply effect 

        //Show Text
        ShowFloatingText("Speed Increased");
        //remove powerup 
        Destroy(gameObject);
    }

    void ShowFloatingText(string text)
    {
        GameObject prefab = Instantiate(FloatingText, transform.position, Quaternion.identity);
        prefab.GetComponentInChildren<TextMesh>().text = text;
    }
}
