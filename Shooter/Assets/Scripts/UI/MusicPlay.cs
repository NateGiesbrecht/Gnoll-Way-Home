using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlay : MonoBehaviour
{
    public AudioSource audioSource; 
    public GameObject objectMusic; 
    public TimeController timeController;
    public AudioClip[] songs; 
    // Start is called before the first frame update
    void Start()
    {
        objectMusic = GameObject.FindWithTag("GameMusic");
        audioSource = objectMusic.GetComponent<AudioSource>(); 
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!audioSource.isPlaying)
        {
            audioSource.clip = GetRandomClip();
            audioSource.Play();
        }

        
    }

    private AudioClip GetRandomClip()
    {
        return songs[Random.Range(0,songs.Length)];
    }
}
