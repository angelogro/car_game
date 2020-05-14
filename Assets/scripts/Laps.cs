 using UnityEngine;
 using System.Collections;
 using UnityEngine.UI;
 
 public class Laps : MonoBehaviour {
     public delegate void GameDelegate();
     public event GameDelegate OnCountCheckpointUp;
     public event GameDelegate OnLapUp;
     // These Static Variables are accessed in "checkpoint" Script
     public Transform[] checkPointArray;
     public Transform[] checkpointA;
     public int currentCheckpoint = 0; 
     public int currentLap = 0; 
     public Vector3 startPos;
     public int Lap;
     public RectTransform panel;
     
     void Awake(){
         checkpointA = checkPointArray;
     }

     void  Start ()
     {
         startPos = transform.position;
         currentCheckpoint = 0;
         currentLap = 0; 
     }
 

     
     public void CheckpointTriggered(){
         OnCountCheckpointUp();
     }

     public void NewLapTriggered(){
         Lap = currentLap;
         OnLapUp();
     }
 }