using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]

public class LapTime : MonoBehaviour
{
    public GameObject player;
    Laps laps;
    public delegate void GameDelegate();
    public event GameDelegate OnBestTimeAchieved;
    public event GameDelegate OnLapFinished;
    Text laptext;
    float initialTime;
    public float bestTime=10000000000;
    public List<float> lapResults;
    // Start is called before the first frame update
    void Awake(){
        laps = player.GetComponent<Laps>();
        lapResults = new List<float>();
        laptext = GetComponent<Text>(); 
        laptext.text = "Laptime: 00:00:000";
    }

    void OnEnable(){
        laps.OnLapUp += OnLapUp; 
    }

    void OnDisable(){
        laps.OnLapUp -= OnLapUp; 
    }

    void OnLapUp(){
        lapResults.Add(Time.time-initialTime);
        OnLapFinished();
        if(lapResults[lapResults.Count-1]<bestTime){
            bestTime = lapResults[lapResults.Count-1];
            OnBestTimeAchieved();
        }
        
        laptext.text = "Laptime: 00:00:000";
        initialTime = Time.time;
    }

    void FixedUpdate(){
        laptext.text = "Laptime: "+(Time.time-initialTime).ToString("00:00.000");
    }
}
