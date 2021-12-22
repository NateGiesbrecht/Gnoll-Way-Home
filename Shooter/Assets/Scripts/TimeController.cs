using UnityEngine;

public class TimeController : MonoBehaviour
{
    public float slowdownFactor = 0.05f; 
    public float slowdownLength = 2f; 
    //public float slowDownLengthDeath = 0.5f;

    public GameController gameController;
    bool paused; 
    public float pitch; 

    void Update()
    {
        paused = gameController.paused; 
        if(!paused)
        {
            Time.timeScale += (1f/slowdownLength) * Time.unscaledDeltaTime;   //How long we will slow down 
            Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);  //Stops game from speeding up like crazy from above equation

        }
        else
        {
            Time.timeScale = 0; 
        }
    }
    public void DoSlowMotion()
    {
        slowdownLength = 2f;
        Time.timeScale = slowdownFactor; 
        Time.fixedDeltaTime = Time.timeScale * .02f; //Makes game not look laggy during slow 
        
    }

    public void DoSlowMotion2()
    {
        slowdownLength = 0.3f;
        Time.timeScale = slowdownFactor; 
        Time.fixedDeltaTime = Time.timeScale * .02f; //Makes game not look laggy during slow 
        
    }

    

    public float GetPitch()
    {
        return this.pitch; 
    }
}
