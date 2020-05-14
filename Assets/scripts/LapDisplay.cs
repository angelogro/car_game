using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]

public class LapDisplay : MonoBehaviour
{
    Text checkpoints;
    public GameObject player;
    Laps laps;
    // Start is called before the first frame update
    void Awake(){
        laps = player.GetComponent<Laps>();
        checkpoints = GetComponent<Text>(); 
        checkpoints.text = "Lap: 0";
    }

    void OnEnable(){
        laps.OnLapUp += OnLapUp; 
    }

    void OnDisable(){
        laps.OnLapUp -= OnLapUp; 
    }

    void OnLapUp(){
        checkpoints.text = "Lap: "+laps.currentLap.ToString();
    }
}

