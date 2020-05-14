using System.Linq.Expressions;
using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skidmarks : MonoBehaviour
{
    public WheelCollider coll;
    public GameObject skidmarkPrefab;
    WheelHit wheelHit;
    TrailRenderer tr;
    


    void Start(){
        tr = skidmarkPrefab.GetComponent<TrailRenderer>();
    }

    void FixedUpdate(){
        if (!coll.GetComponent<WheelCollider>().GetGroundHit(out wheelHit)){
            tr.emitting = false;
            return;
        }
        if(wheelHit.collider.tag=="Terrain"){
            tr.emitting = false;
            return;
        }
            
        
        if(wheelHit.sidewaysSlip>0.6 | wheelHit.forwardSlip>0.9){
            tr.emitting = true;
        } else if(wheelHit.sidewaysSlip<=0.6 && wheelHit.forwardSlip<=0.9) {
            tr.emitting = false;
        }
    }
}
