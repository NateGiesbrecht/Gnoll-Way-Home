using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PowerUpDisplay : MonoBehaviour
{
    public TMP_Text speedUp; 
    public TMP_Text fireRateUp; 
    public PlayerController player; 
    

    // Update is called once per frame
    void Update()
    {
        speedUp.text = player.speedUpItems.ToString("00");
        fireRateUp.text = player.fireRateItems.ToString("00"); 
    }
}
