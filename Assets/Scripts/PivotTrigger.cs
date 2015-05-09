using UnityEngine;
using System.Collections;

public class PivotTrigger : MonoBehaviour {

    GameObject UIManager;
    public bool disableColliderOnDrop = false;

    [HideInInspector] public bool isAttached = false;
	// Use this for initialization
	void Start () 
    {
	   UIManager = GameObject.Find("UIManager");
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (isAttached)
        {
            return;
        }
        if (col.tag == "Pivot")
        {
            UIManager.GetComponent<Parts_GUI_Manager_Script>().DropObject(col.transform);
        }
    }
}
