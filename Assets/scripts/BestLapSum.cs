using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class BestLapSum : MonoBehaviour
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
        laptime.OnLapFinished += OnLapFinished; 
    }

    void OnDisable(){
        laptime.OnLapFinished -= OnLapFinished; 
    }

    void OnLapFinished(){
        if(laptime.bestTime>100000000)
            return;
        text.enabled = true;
        float result = laptime.bestTime -laptime.lapResults[laptime.lapResults.Count-1];
        if(result >0){
            StartCoroutine("MakeGreen");
            text.text = "+ "+result.ToString("00:00.000");
        }
            
        else{
            StartCoroutine("MakeRed");
            text.text = result.ToString("00:00.000");
        }
    }

    IEnumerator MakeGreen(){
        int i = 209;
        while(i>50){
            text.color = new UnityEngine.Color(0.2f,i/255f,0.2f,1.0f);
            yield return new WaitForSeconds(0.2f);
            i = i-10;
        }
        text.enabled = false;
    }


    IEnumerator MakeRed(){
        int i = 209;
        while(i>50){
            text.color = new UnityEngine.Color(i/255f,0.2f,0.2f,1.0f);
            yield return new WaitForSeconds(0.2f);
            i = i-10;
        }
        text.enabled = false;
    }
}
