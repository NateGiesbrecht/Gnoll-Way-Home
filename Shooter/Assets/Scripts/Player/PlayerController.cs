using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    

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
     
    


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = 4; 
        maxHealth = 4;
        //timeBetweenShots = startTimeBetweenShots;
    }

    void Update()
    {
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
        }
    }

    public void increaseSpeed(float increase)
    {
        this.speed += increase; 
    }

    public void restoreHealth(int increase)
    {
        this.health += increase; 
    }

    public void increaseFireRate(float increase)
    {
        this.fireRate -= increase;
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
}
