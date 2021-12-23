using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{

    public bool thrown;
    public float Speed = 5;
    
    public Vector2 targetPos;

    public GameObject explosion;

    private Shake shake;
    // Start is called before the first frame update
    void Start()
    {
        targetPos = GameObject.Find("GrenadeDir").transform.position;
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Speed > 0)
        {
            Speed -= Random.Range(.1f, .25f);
            transform.position = Vector2.MoveTowards(transform.position, targetPos, Speed * Time.deltaTime);     
        }
        else if (Speed < 0)
        {
            Speed = 0;
            //add explosion 
            StartCoroutine(Explode(1));
        }
    }

    IEnumerator Explode( float time)
    {
        yield return new WaitForSeconds(time); 
        Destroy(gameObject);
        Instantiate(explosion, transform.position, Quaternion.identity);
        shake.CamShake();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        switch(other.gameObject.tag)
        {
            case "Wall":
                Speed = 0;
                return; 
            case "Enemy":
                StartCoroutine(Explode(0));
                Debug.Log("HIT");
                break;
            case "EnemyGnoll":
                StartCoroutine(Explode(0));
                Debug.Log("HIT");
                break;
            case "EnemyGiant":
                StartCoroutine(Explode(0));
                Debug.Log("HIT");
                break;
        }
        // if(target.gameObject.tag == "Enemy" ) StartCoroutine(Explode(0));  //Do this for each ennemy. Expldoe immediately on impact 
        // if(target.gameObject.tag == "EnemyGnoll" ) StartCoroutine(Explode(0));  //Do this for each ennemy. Expldoe immediately on impact 
        // if(target.gameObject.tag == "EnemyGiant" ) StartCoroutine(Explode(0));  //Do this for each ennemy. Expldoe immediately on impact 
    }
}
