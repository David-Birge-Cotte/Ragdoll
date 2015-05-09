using UnityEngine;
using System.Collections;

public class PivotTrigger : MonoBehaviour {

    private GameObject UIManager;
    private GameObject pivotToBeAttached;
	// Use this for initialization
	void Start () 
    {
	   UIManager = GameObject.Find("UIManager");
	}
	
	// Update is called once per frame
	void Update () 
    {
        if ( UIManager.GetComponent<Parts_GUI_Manager_Script>().SelectedObject != gameObject )
            return;
            
        if (Input.GetMouseButtonUp(0))
        {
            if ( pivotToBeAttached == null)
            {
                Debug.Log("you dropped in the void");
                UIManager.GetComponent<Parts_GUI_Manager_Script>().SelectedObject = null;
                Destroy(gameObject);
                return;
            }
            else
            {
                UIManager.GetComponent<Parts_GUI_Manager_Script>().DropObject(pivotToBeAttached.transform);
            }
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {       
        if (col.tag == "Pivot")
        {
            Debug.Log("you are entering a pivot");
            pivotToBeAttached = col.gameObject;
            col.GetComponentInChildren<PivotScript>().transform.localScale = new Vector3(2, 2, 1);
        }

       
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Pivot")
        {
            Debug.Log("you are leaving a pivot");
            pivotToBeAttached = null;
            col.GetComponentInChildren<PivotScript>().transform.localScale = Vector3.one;
        }
    }
}
