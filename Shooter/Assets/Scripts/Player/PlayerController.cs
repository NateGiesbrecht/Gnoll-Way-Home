using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    
    //Skin selector 
    public SpriteRenderer spriteRenderer; 
    public Sprite[] skins; 
    public AnimatorOverrideController redAnimController;
    public AnimatorOverrideController blueAnimController;
    public AnimatorOverrideController purpleAnimController;
    public Material flash;
    public Material normal; 


    public Camera sceneCamera; 
    public Weapon weapon; 
    private Rigidbody2D rb;

    
    private Vector2 mousePosition; 


    public Animator animator; 

    //Stats 
    public int health; 
    public int maxHealth; 
    private Vector2 moveVelocity;
    public float speed = 10f;
    private bool canTakeDamage;

    //Items 
    public int speedUpItems = 0;
    public int fireRateItems = 0 ; 
    


    //Coins
    private int coins; 

    [SerializeField] public FlashScript flashEffect;

    //Weapon Stuff 
    public float fireRate = 1f;
    private float nextFire = 0f; 

    //Death 
    public bool isDead = false; 

    //Physics 
    public float knockBackForce;
    private bool beingKnockedBack; 

    //Sound
    public AudioClip hurtSound; 
    public AudioClip step; 
    public AudioClip step2; 

    //Effects
    public ParticleSystem dust; 

    //Time 
    public TimeController timeController; 

     
     
    


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = 4; 
        maxHealth = 4;
        //timeBetweenShots = startTimeBetweenShots;
        string skin = PlayerPrefs.GetString("EquipedSkin", "Default");
        
        //Set skin during countdown 
        
        switch(skin)
        {
            case "Default":
                spriteRenderer.sprite = skins[0];
                break;
            case "Red":
                spriteRenderer.sprite = skins[1];
                RedSkin();
                break;
            case "Blue": 
                spriteRenderer.sprite = skins[2];
                BlueSkin();
                break;
            case "Purple":
                spriteRenderer.sprite = skins[3];
                PurpleSkin();
                break;
        }
 
        //setSkinAnimator();

    }

    void Update()
    {
        //RedSkin();
        if(isDead)
        {
            Destroy(gameObject);
            return; 
        }
        if(this.health <= 0)
        {
            isDead = true;
        }
        ProcessInput();
        if(mousePosition.x < rb.position.x)
        {
            animator.SetBool("left", true);
            animator.SetBool("right", false);
        }else{
            animator.SetBool("left", false);
            animator.SetBool("right", true);
        }

        if(moveVelocity.x == 0&& moveVelocity.y == 0)
        {   
            animator.SetBool("moving", false);
            
        }else{
            animator.SetBool("moving", true);
            CreateDust();
            
        }
    }

    

    void FixedUpdate()
    {
        //Move(); 
        if(!beingKnockedBack){
            canTakeDamage = true; 
            Move(); 
        }else{
            canTakeDamage = false; 
        }
        
    }

    void Move()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
        

        //Rotate player to follow mouse
        Vector2 aimDirection = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f; 
        //rb.rotation = aimAngle;
    }

    void ProcessInput()
    {
        //Knockback test 
        // if (Input.GetKeyDown(KeyCode.Space)){
        //     knockBack();
        //     Debug.Log("space");
            
        //     Vector2 direction = (enemy.transform.position - this.transform.position).normalized;
        //     rb.AddForce(-direction * 10f);
        // }



        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed; 

        // while(Input.GetMouseButton(0))
        // {
            if(Input.GetMouseButton(0) && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                weapon.fire(); 
            }
        //}

        mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition); 
    }

    public int getHealth()
    {
        return this.health;
    }

    public void reduceHealth(int dmg)
    {
        if(canTakeDamage){
            this.health -= dmg; 
            flashEffect.Flash();
            AudioSource.PlayClipAtPoint(hurtSound, transform.position);

            timeController.DoSlowMotion();

        }
    }

    public void increaseSpeed(float increase)
    {
        this.speed += increase; 
        speedUpItems++;
    }

    public void restoreHealth(int increase)
    {
        this.health += increase; 
    }

    public void increaseFireRate(float increase)
    {
        this.fireRate -= increase;
        fireRateItems++;
    }

    public void increaseCoins(int increase)
    {
        this.coins += increase;
        //PlayerPrefs.SetInt("coins", this.coins);
        
    }

    public int getCoins()
    {
        return this.coins;
    }

    public IEnumerator knockBack(float knockBackDuration, float knockBackPower, Transform obj)
    {
            float timer = 0; 
            beingKnockedBack = true;

            
            while( knockBackDuration > timer)
            {
                timer += Time.deltaTime;

                Vector2 direction = (obj.transform.position - this.transform.position).normalized;
                rb.velocity = -direction * knockBackPower;

                yield return null; // yield for a frame
            }
            beingKnockedBack = false;
             
    }

    public void RedSkin()
    {
        animator.runtimeAnimatorController = redAnimController;
    }
    public void PurpleSkin()
    {
        animator.runtimeAnimatorController = purpleAnimController;
    }
    public void BlueSkin()
    {
        animator.runtimeAnimatorController = blueAnimController;
    }

    private void Footstep()
    {
        AudioSource.PlayClipAtPoint(step, transform.position, 0.4f);
    }

    private void Footstep2()
    {
        //step.volume(0.1f);
        AudioSource.PlayClipAtPoint(step2, transform.position, 0.4f);
    }

    private void CreateDust()
    {
        dust.Play();
    }

}
