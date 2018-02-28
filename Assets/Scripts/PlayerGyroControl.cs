using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGyroControl : MonoBehaviour {

    private bool gyroEnabled;
   
    private Gyroscope gyro;
    private Quaternion rot;
    public GameObject Player;

  
    
    
   
   
    void Start ()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
       
       
        Player.transform.position = transform.position;
        transform.SetParent(Player.transform);
        gyroEnabled = EnableGyro();
    }
	
	
	void Update () {

      

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

            Player.transform.rotation = Quaternion.Euler(90f, 90f, 0f);
            rot = new Quaternion(0, 0, 1, 0);
            return true;
        }
        return false;
    }

  

}
