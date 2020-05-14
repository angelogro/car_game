
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCarController : MonoBehaviour
{
    public string horizontal_axis;
    public string vertical_axis;
    public string respawn_key;


    public void GetInput(){
        m_horizontalInput = Input.GetAxis(horizontal_axis);
        m_verticalInput = Input.GetAxis(vertical_axis);
        if(Input.GetKeyDown(respawn_key)){
            respawn();
            
        }
    }

    private void respawn(){
        int nextCheckpoint = GetComponent<Laps>().currentCheckpoint;
        int currentCheckpoint = nextCheckpoint - 1;
        if(currentCheckpoint<0)
            currentCheckpoint = GetComponent<Laps>().checkPointArray.Length-1;
        Vector3 respawnPosition = GetComponent<Laps>().checkPointArray[currentCheckpoint].position;
        respawnPosition.y = 2;
        GetComponent<Transform>().position = respawnPosition;
        GetComponent<Transform>().rotation = GetComponent<Laps>().checkPointArray[currentCheckpoint].rotation;
        frontDriverWheel.motorTorque = 0;
        frontPassengerWheel.motorTorque =0;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

    }

    private void Steer(){
        m_steeringAngle = maxSteerAngle * m_horizontalInput;
        frontDriverWheel.steerAngle = m_steeringAngle;
        frontPassengerWheel.steerAngle = m_steeringAngle;
    }

    private void Accelerate(){
        frontDriverWheel.motorTorque = m_verticalInput * motorForce;
        frontPassengerWheel.motorTorque = m_verticalInput *motorForce;
        if(m_verticalInput>=1){
            if(!smoke.isPlaying)
                smoke.Play();

        } else {
            if(smoke.isPlaying)
                smoke.Stop(true,ParticleSystemStopBehavior.StopEmitting);
        }
    }

    private void UpdateWheelPoses(){
        UpdateWheelPose(frontDriverWheel,frontDriverTransform);
        UpdateWheelPose(frontPassengerWheel,frontPassengerTransform);
        UpdateWheelPose(rearDriverWheel,rearDriverTransform);
        UpdateWheelPose(rearPassengerWheel,rearPassengerTransform);
    }

    private void UpdateWheelPose(WheelCollider _coll,Transform _trans){
        UnityEngine.Vector3 _pos = _trans.position;
        UnityEngine.Quaternion _quat = _trans.rotation;

        _coll.GetWorldPose(out _pos,out _quat);

        _trans.position = _pos;
        _trans.rotation = _quat;
    }

    private void FixedUpdate(){
        GetInput();
        Steer();
        Accelerate();
        UpdateWheelPoses();

        
    }

    private float m_horizontalInput,m_steeringAngle,m_verticalInput;
    public float maxSteerAngle = 30;
    public float motorForce = 50;

    public WheelCollider frontDriverWheel,frontPassengerWheel;
    public WheelCollider rearDriverWheel,rearPassengerWheel;

    public Transform frontDriverTransform,frontPassengerTransform;
    public Transform rearDriverTransform,rearPassengerTransform;

    public ParticleSystem smoke;

}
