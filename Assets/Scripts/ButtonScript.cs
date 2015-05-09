using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour {

    public int SerialNumber;
    GameObject UImanager;
	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Button>().onClick.AddListener(() => { GetPart(); });
        UImanager = GameObject.Find("UIManager");
	}
	
	// Update is called once per frame
	void Update () {

        

	}

    void GetPart()
    {
        if (UImanager.GetComponent<Parts_GUI_Manager_Script>().AnObjectIsSelected == false)
        UImanager.GetComponent<Parts_GUI_Manager_Script>().GrabPart(SerialNumber);

    }



    
}
