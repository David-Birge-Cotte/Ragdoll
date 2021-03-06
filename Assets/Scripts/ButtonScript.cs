﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour {

    public int SerialNumber;
    GameObject UImanager;
	// Use this for initialization
	void Start () {
        //gameObject.GetComponent<Button>().OnPointerDown.AddListener(() => { GetPart(); });
        UImanager = GameObject.Find("UIManager");
	}

    public void GetPart()
    {
        if ( UImanager.GetComponent<Parts_GUI_Manager_Script>().SelectedObject == null )
        {
            UImanager.GetComponent<Parts_GUI_Manager_Script>().GrabPart(SerialNumber);
            GetComponent<AudioSource>().Play();
        }
    }
}
