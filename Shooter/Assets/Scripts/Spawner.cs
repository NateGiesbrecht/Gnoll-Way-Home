using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    public GameObject enemyObject;
    public GameObject enemyGnollObject;
    public GameObject enemyGiantObject;
    public GameObject HealthUp;
    public GameObject SpeedUp;
    public GameObject FireRateUp;
    public float secondsBetweenSpawn;
     public float elapsedTime = 0.0f;
     public float radius = 1;
    
    public int maxTime = 2;
    public int minTime = 1;

    public Transform[] spawnPoints; 
    public PlayerController player; 

    //current time
     private float time;
 
     //The time to spawn the object
     private float spawnTime;
       
    
    void Start()
    {
       SetRandomTime();
       time = 0; 
    }
     void Update()
     {
         if(player.isDead)
         {
             return; 
         }
        Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
         elapsedTime += Time.deltaTime;
        int enemyToSpawn = (int)Random.Range(0,3);
         if (elapsedTime > secondsBetweenSpawn)
         {
             elapsedTime = 0;
             //Debug.Log("Spawning");   
            
            GameObject newEnemy;
            switch(enemyToSpawn)
            {
                case 0: 
                    newEnemy = (GameObject)Instantiate(enemyObject, randomPoint.position, Quaternion.Euler (0, 0, 0));
                    break;
                case 1: 
                    newEnemy = (GameObject)Instantiate(enemyGnollObject, randomPoint.position, Quaternion.Euler (0, 0, 0));
                    break;
                case 2:
                    newEnemy = (GameObject)Instantiate(enemyGiantObject, randomPoint.position, Quaternion.Euler (0, 0, 0));
                    break;
            }
              //Vector3 spawnPosition = Random.insideUnitCircle * radius;
              
         }
     }

     void FixedUpdate()
     {  
         if(player.isDead)
         {
             return; 
         }
         //counts up 
         time += Time.deltaTime;

         if(time >= spawnTime)
         {
             SpawnObject();
             SetRandomTime();
             time = 0;
         }
         //Debug.Log("Time: " + time + " and spawnTime " + spawnTime);
     }

     //Spawns the object and resets the time
     void SpawnObject(){
         int itemToSpawn = (int)Random.Range(0,3);
         Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
         switch(itemToSpawn){
             case 0:
                GameObject newSpeedUp = (GameObject)Instantiate(HealthUp, randomPoint.position, Quaternion.Euler (0, 0, 0));
                break;
             case 1:
                GameObject newHealthUp = (GameObject)Instantiate(SpeedUp, randomPoint.position, Quaternion.Euler (0, 0, 0));
                break;
             case 2:
                GameObject newRateUp = (GameObject)Instantiate(FireRateUp, randomPoint.position, Quaternion.Euler (0, 0, 0));
                break;
         }
         
     }

     //Sets the random time between minTime and maxTime
     void SetRandomTime(){
         spawnTime = Random.Range(minTime, maxTime);
     }

    //  private void OnDrawGizmos()
    //  {
    //      Gizmos.color = Color.green;
    //      Gizmos.DrawWireSphere(this.transform.position, radius);
    //  }
}
