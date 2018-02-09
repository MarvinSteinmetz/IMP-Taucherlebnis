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

        if (gyroEnabled)
        {
            transform.localRotation = gyro.attitude * rot;


            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                accel = true;
            }
            if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                accel = false;
            }
            if (accel)
            {
                CameraContainer.transform.position = transform.position + Camera.main.transform.forward * distance * Time.deltaTime;
            }

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


}
