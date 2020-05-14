
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fence : MonoBehaviour
{
    public int amountParticles;
    public GameObject particle;
    public float relativeVelocityNecessary;
    List<Vector3> randPositions;
    
    void Awake(){
        randPositions = new List<Vector3>();
        for(int i=0;i<amountParticles;i++){
            randPositions.Add(getRandomPosition());
        }
    }
    // Start is called before the first frame update
    void OnCollisionEnter(Collision collision){
        if(collision.collider.tag=="Player1"|collision.collider.tag=="Player2"){
            if (collision.relativeVelocity.magnitude > relativeVelocityNecessary){
                for(int i=0;i<amountParticles;i++){
                    GameObject part;
                    part = Instantiate(particle,randPositions[i],Quaternion.identity);
                    part.GetComponent<Rigidbody>().velocity = collision.relativeVelocity/amountParticles;
                }
                Destroy(gameObject);
            }
            
            
        }  
    }


    Vector3 getRandomPosition(){
         float randomX = Random.Range (transform.position.x - transform.localScale.x / 2, transform.position.x + transform.localScale.x / 2); 
         float randomY = Random.Range (transform.position.y - transform.localScale.y / 2, transform.position.y + transform.localScale.y / 2); 
         float randomZ = Random.Range (transform.position.z - transform.localScale.z / 2, transform.position.z + transform.localScale.z / 2); 
         Vector3 randomPosition = new Vector3 (randomX, randomY, randomZ);
         return randomPosition;
    }
}
