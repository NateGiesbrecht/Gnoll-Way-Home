using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractorScript : MonoBehaviour
{
    private float speed = 8;
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            transform.position = Vector2.MoveTowards(transform.position, other.transform.position, speed * Time.deltaTime);
        }

    }

    private void Update()
    {
        if (transform.childCount < 1)
        {
            Destroy(gameObject);
        }
    }
}
