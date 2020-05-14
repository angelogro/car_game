using System.Threading;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCameraFollowController : MonoBehaviour
{
    public Transform objectToFollow;
    public UnityEngine.Vector3 offset;
    public float followSpeed = 10;
    public float lookSpeed = 10 ;

    public void LookAtTarget(){
        UnityEngine.Vector3 _lookDirection = objectToFollow.position -transform.position;
        UnityEngine.Quaternion _rot = UnityEngine.Quaternion.LookRotation(_lookDirection,UnityEngine.Vector3.up);
        transform.rotation = UnityEngine.Quaternion.Lerp(transform.rotation,_rot,lookSpeed * Time.deltaTime);
    }

    public void MoveToTarget(){
        UnityEngine.Vector3 _targetPos = objectToFollow.position + objectToFollow.forward * offset.z + objectToFollow.right * offset.x +
                                objectToFollow.up * offset.y;
        transform.position = UnityEngine.Vector3.Lerp(transform.position, _targetPos, followSpeed * Time.deltaTime);
                            
    }

    public void FixedUpdate(){
        LookAtTarget();
        MoveToTarget();
    }
}
