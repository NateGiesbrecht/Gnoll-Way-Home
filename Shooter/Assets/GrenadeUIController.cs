using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GrenadeUIController : MonoBehaviour
{

    public PlayerController player;
    public TMP_Text grenadeText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        grenadeText.text = player.getGrenades().ToString(); 
    }
}
