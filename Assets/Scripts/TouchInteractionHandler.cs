using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInteractionHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        for (int i = 0; i < Input.touchCount; ++i)
        {
            //on doubleclick testing!!!!!!
            if ( Input.touchCount>1&&Input.GetTouch(i).phase == TouchPhase.Began)
            {
                RaycastHit hit;
                // Construct a ray from the current touch coordinates
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
               
                if (Physics.Raycast(ray,out hit))
                {
                    //on RaycastHit handle output
                    Vector3 temp = hit.transform.position;
                    temp.x += 3;
                    hit.transform.position = temp;
                }      
            }
        }
    }
}
