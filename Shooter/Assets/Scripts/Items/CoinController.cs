using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinController : MonoBehaviour
{

    public PlayerController player; 
    public TMP_Text coinDisplay; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        coinDisplay.text = player.getCoins().ToString(); 
    }
}
