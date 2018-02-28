using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public Text UI_Name;
    public Text UI_FlavorText;
    public Image UI_Image_L;
    public Image UI_Image_R;
    public GameObject MainUI;
    public Button swimButton;
    
    public NPC_Controller ObjectData;
    

	// Use this for initialization
	void Start () {
        SetElements(ObjectData);
        ShowUI(true);
       
     
	}
	
	// Update is called once per frame
	void Update () {


        Ray ray;
        RaycastHit hit;

        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {


                ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);


                if (Physics.Raycast(ray, out hit))
                {
                    //on RaycastHit handle output
                    if (hit.transform.gameObject.tag == "ClickableObject")
                    {
                        ObjectData = hit.transform.gameObject.GetComponent<NPC_Controller>();
                        SetElements(ObjectData);
                        print(ObjectData.name);
                    }
                }
            }
        }
        
    }
    public void ShowUI(bool value)
    {
        MainUI.SetActive(value);
        if (value)
        {
            swimButton.interactable = false;
        }
        else {
            swimButton.interactable = true;
        }
    }

    private void SetElements(NPC_Controller hitData)
    {
        UI_Name.text = hitData.ObjectName;
        UI_FlavorText.text = hitData.ObjectFlavortext;
        UI_Image_L.sprite = hitData.ObjectImageLeft;
        UI_Image_R.sprite = hitData.ObjectImageRight;
        ShowUI(true);
    }
}
