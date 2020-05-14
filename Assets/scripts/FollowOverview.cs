
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowOverview : MonoBehaviour
{
    public GameObject objectToFollow;
    public Vector3 offset;
    public float followSpeed;


    public void MoveToTarget(){
        UnityEngine.Vector3 _targetPos;
        _targetPos = (objectToFollow.transform.position.x+offset.x)*Vector3.right+(objectToFollow.transform.position.z+offset.z)*Vector3.forward+offset.y*Vector3.up;
        
        //
        transform.position = UnityEngine.Vector3.Lerp(transform.position, _targetPos, followSpeed * Time.deltaTime);
                            
    }

    void FixedUpdate(){
        MoveToTarget();

    }
}
