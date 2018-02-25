using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public Text UI_Name;
    public Text UI_FlavorText;
    public Image UI_Image;
    public GameObject MainUI;
    
    public NPC_Controller ObjectData;
    

	// Use this for initialization
	void Start () {
        SetElements(ObjectData);
        ShowUI(true);
       
     
	}
	
	// Update is called once per frame
	void Update () {

        for (int i = 0; i < Input.touchCount; ++i)
        {
            
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                RaycastHit hit;
                // Construct a ray from the current touch coordinates
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);

                if (Physics.Raycast(ray, out hit))
                {
                    //on RaycastHit handle output
                    ObjectData = hit.transform.gameObject.GetComponent<NPC_Controller>();
                    SetElements(ObjectData);
                }
            }
        }
    }
    public void ShowUI(bool value)
    {
        MainUI.SetActive(value);
    }

    private void SetElements(NPC_Controller hitData)
    {
        UI_Name.text = hitData.ObjectName;
        UI_FlavorText.text = hitData.ObjectFlavortext;
        ShowUI(true);
    }
}
