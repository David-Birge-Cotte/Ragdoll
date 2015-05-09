using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BindToLamb : MonoBehaviour {

    public int SerialNumber;
    public GameObject LinkedObject;
    bool playerIsChoosing = false;
    int i;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (playerIsChoosing && Input.anyKeyDown)
        {
            Debug.Log((string)Input.inputString); 
        }

	}

    public void PlayerClickedOnTheButton()
    {
        gameObject.GetComponentInChildren<Text>().text = "";
        playerIsChoosing = true;

    }
}
