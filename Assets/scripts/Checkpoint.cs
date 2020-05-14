
using System.Diagnostics;

 using UnityEngine;
 using System.Collections;
 
 public class Checkpoint : MonoBehaviour {
     public GameObject player_1;
     public GameObject player_2;
     
     Laps choosen_laps;
     
     void  Start ()
     {
 
     }
     
     void  OnTriggerEnter ( Collider other  )
     {
         //Is it the Player who enters the collider?
         if ((!other.CompareTag("Player1"))&&(!other.CompareTag("Player2"))) 
            return;
         //    return; //If it's not the player doLapsnt continue
         if (other.CompareTag("Player1")){
             choosen_laps = player_1.GetComponent<Laps>();
         }
         if (other.CompareTag("Player2")){
             choosen_laps = player_2.GetComponent<Laps>();
         }

 
         if (transform == choosen_laps.checkpointA[choosen_laps.currentCheckpoint].transform) 
         {
             
             //Check so we dont exceed our checkpoint quantity

                 //Add to currentLap if currentCheckpoint is 0
                 if(choosen_laps.currentCheckpoint == choosen_laps.checkpointA.Length-1){
                     choosen_laps.NewLapTriggered();
                     choosen_laps.currentLap++;
                     choosen_laps.currentCheckpoint = 0;
                 }
                     
                 choosen_laps.currentCheckpoint++;
                 
             

         }
         choosen_laps.CheckpointTriggered();
 
 
     }
 
 }
