using System.Diagnostics;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class BestLap : MonoBehaviour
{
    Text text;
    public GameObject txtLapTime;
    LapTime laptime;

    void Awake(){
        laptime = txtLapTime.GetComponent<LapTime>();
    }

    void Start(){
        
        text = GetComponent<Text>();
        text.enabled = false;
    }

    void OnEnable(){
        laptime.OnBestTimeAchieved += OnBestTimeAchieved; 
    }

    void OnDisable(){
        laptime.OnBestTimeAchieved -= OnBestTimeAchieved; 
    }

    void OnBestTimeAchieved(){
        text.enabled = true;
        UnityEngine.Debug.Log(laptime.bestTime.ToString());
        text.text = "Best Lap: "+laptime.bestTime.ToString("00:00.000");
        StartCoroutine("MakeGreen");
    }

    IEnumerator MakeGreen(){
        UnityEngine.Debug.Log("Green");
        int i = 209;
        while(i>50){
            text.color = new UnityEngine.Color(0.2f,i/255f,0.2f,1.0f);
            yield return new WaitForSeconds(0.1f);
            i = i-10;
        }
    }
    
}
