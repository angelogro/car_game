using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]

public class CheckpointDisplay : MonoBehaviour
{
    Text checkpoints;
    int amountOfCheckpoints;
    public GameObject player;
    Laps laps;
    
    // Start is called before the first frame update
    void Awake(){
        laps= player.GetComponent<Laps>();
        checkpoints = GetComponent<Text>();        
    }

    void Start(){
        amountOfCheckpoints = laps.checkpointA.Length;
        checkpoints.text = "Checkpoint: 0 of "+amountOfCheckpoints.ToString();
    }


    void OnEnable(){
        laps.OnCountCheckpointUp += OnCountCheckpointUp; 
    }

    void OnDisable(){
        laps.OnCountCheckpointUp -= OnCountCheckpointUp; 
    }

    void OnCountCheckpointUp(){
        checkpoints.text = "Checkpoint: "+laps.currentCheckpoint.ToString()+" of "+amountOfCheckpoints.ToString();
    }
}
