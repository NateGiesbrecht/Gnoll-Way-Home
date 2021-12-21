using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class GiantGFX : MonoBehaviour
{
    public AIPath aiPath; 
    public Animator animator; 
    [SerializeField] public FlashScript flashEffect;

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
}
