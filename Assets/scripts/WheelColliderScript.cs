using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelColliderScript : MonoBehaviour
{
    WheelHit wheelHit;
    public GameObject tireRubber;
    public GameObject player;
    public float terrainDragAdded;
    bool terrainDragApplied = false;

    void FixedUpdate(){
        if (!GetComponent<WheelCollider>().GetGroundHit(out wheelHit))
            return;
  /*      if(wheelHit.sidewaysSlip>0.5 | wheelHit.forwardSlip>0.8 ){
            Instantiate(tireRubber,wheelHit.point,Quaternion.identity);
            
            // Add sound later on
        }
*/      
        if(wheelHit.collider.tag=="Terrain"&&!terrainDragApplied){
            player.GetComponent<Rigidbody>().drag += terrainDragAdded;
            terrainDragApplied=true;
        }     
        else if(!(wheelHit.collider.tag=="Terrain")&&terrainDragApplied){
            player.GetComponent<Rigidbody>().drag -= terrainDragAdded;
            terrainDragApplied=false;
        }
            
    }
        
}
