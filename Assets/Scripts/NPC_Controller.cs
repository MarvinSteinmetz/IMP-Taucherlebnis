using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NPC_Controller : MonoBehaviour {

    public string ObjectName;
    public string ObjectFlavortext;
    public Sprite ObjectImageLeft;
    public Sprite ObjectImageRight;

    public Vector3[] points;
    public int iterator;
    public float speed;
    public float turnRate;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        PatrolWaypoints();
	}

    void PatrolWaypoints()
    {
       if (Vector3.Distance(transform.position,points[iterator])<3)
        {
            iterator++;
            if (iterator == points.Length)
            {
                iterator = 0;
            }
        }   
     transform.position = Vector3.MoveTowards(transform.position, points[iterator], speed*Time.deltaTime);
        Vector3 targetDir = points[iterator] - transform.position;
        
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, turnRate*Time.deltaTime, 0.0F);
      
        transform.rotation = Quaternion.LookRotation(newDir);
    }





}
