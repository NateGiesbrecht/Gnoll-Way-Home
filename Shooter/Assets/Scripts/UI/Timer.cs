using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText;
    private float startTime;
    public PlayerController player; 
    public float endTime; 
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time; 
    }

    // Update is called once per frame
    void Update()
    {
        if(!player.isDead){
            float t = Time.time - startTime; 

            string minutes = ((int) t/ 60).ToString();
            string seconds = (t % 60).ToString("00"); 

            timerText.text = minutes + ":" + seconds;
        }
    }
}
