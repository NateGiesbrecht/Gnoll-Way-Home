using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class GiantGFX : MonoBehaviour
{
    public AIPath aiPath; 
    public Animator animator; 
    [SerializeField] public FlashScript flashEffect;

    public AudioClip[] steps;
    public int stepCounter = 0; 

    // Update is called once per frame
    void Update()
    {
        if(aiPath.desiredVelocity.x > 0.01)
        {
            animator.SetBool("left", false);
            animator.SetBool("right", true);
        }
        else{
            animator.SetBool("left", true);
            animator.SetBool("right", false);
        }
    }

    public void flash()
    {
        flashEffect.Flash();
    }

    public void PlayStep()
    {
        int clipToPlay = stepCounter % 3;
         
        AudioSource.PlayClipAtPoint(steps[clipToPlay], transform.position);
        stepCounter++;
    }
}
