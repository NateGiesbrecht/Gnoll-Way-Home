using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicPlayerScript : MonoBehaviour
{
    public AudioSource audioSource; 
    public GameObject objectMusic; 
    private float vol=0.3f; 
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
        audioSource.volume = vol;
    }

    public void updateVolume(float volume)
    {

        vol = volume; 
    }
}
