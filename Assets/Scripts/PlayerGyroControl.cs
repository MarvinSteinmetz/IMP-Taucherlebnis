using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGyroControl : MonoBehaviour {

    private bool gyroEnabled;
    private bool accel=false;
    private Gyroscope gyro;
    private Quaternion rot;
    private GameObject CameraContainer;
    private float distance = 5;
   
   
    void Start ()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
       
        CameraContainer = new GameObject("Camera Container");
        CameraContainer.transform.position = transform.position;
        transform.SetParent(CameraContainer.transform);
        gyroEnabled = EnableGyro();
    }
	
	
	void Update () {

        if (accel)
        {
            CameraContainer.transform.position = transform.position + Camera.main.transform.forward * distance * Time.deltaTime;
        }

        if (gyroEnabled)
        {
            transform.localRotation = gyro.attitude * rot;

        }
    }
    private bool EnableGyro()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
            CameraContainer.transform.rotation = Quaternion.Euler(90f, 90f, 0f);
            rot = new Quaternion(0, 0, 1, 0);
            return true;
        }
        return false;
    }

    public void MoveForward(bool value)
    {
        accel = value;
    }

}
