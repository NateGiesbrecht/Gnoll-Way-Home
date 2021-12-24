using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class musicPlayerScript : MonoBehaviour
{
    public AudioSource audioSource; 
    public AudioClip[] songs; 
    public GameObject objectMusic; 
    private float vol; 
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        
        objectMusic = GameObject.FindWithTag("GameMusic");
        audioSource = objectMusic.GetComponent<AudioSource>(); 
        audioSource.loop = false;
        
        //audioSource.Play();

    }

    // Update is called once per frame
    void Update()
    {
        if(!audioSource.isPlaying)
        {
            audioSource.clip = GetRandomClip();
            audioSource.Play();
        }
        vol = PlayerPrefs.GetFloat("Volume", 0.0f);
        audioSource.volume = vol;
        slider.value = vol; 

    }

    private AudioClip GetRandomClip()
    {
        return songs[Random.Range(0,songs.Length)];
    }

    public void updateVolume(float volume)
    {
        PlayerPrefs.SetFloat("Volume", volume);
        vol = volume; 
    }
}
