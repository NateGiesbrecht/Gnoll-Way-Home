using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class musicPlayerScript : MonoBehaviour
{
    public AudioSource audioSource; 
    public GameObject objectMusic; 
    private float vol; 
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        
        objectMusic = GameObject.FindWithTag("GameMusic");
        audioSource = objectMusic.GetComponent<AudioSource>(); 
        
        //audioSource.Play();

    }

    // Update is called once per frame
    void Update()
    {
        
        vol = PlayerPrefs.GetFloat("Volume", 0.0f);
        audioSource.volume = vol;
        slider.value = vol; 

    }

    public void updateVolume(float volume)
    {
        PlayerPrefs.SetFloat("Volume", volume);
        vol = volume; 
    }
}
