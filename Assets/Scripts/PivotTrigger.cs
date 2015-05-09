using UnityEngine;
using System.Collections;

public class PivotTrigger : MonoBehaviour {

    GameObject UIManager;
    public bool disableColliderOnDrop = false;
    bool ObjectOnTrigger = false;
    GameObject Pivot;

    [HideInInspector] public bool isAttached = false;
	// Use this for initialization
	void Start () 
    {
	   UIManager = GameObject.Find("UIManager");
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetMouseButtonUp(0))
        {
            OMU();
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
       
        if (col.tag == "Pivot")
        {
            ObjectOnTrigger = true;
            Pivot = col.gameObject;
            if (col.GetComponentInChildren<PivotScript>() != null)
            {
                col.GetComponentInChildren<PivotScript>().transform.localScale = new Vector3(2, 2, 1);
            }
            }

       
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Pivot")
        {
            ObjectOnTrigger = false;
            if (col.GetComponentInChildren<PivotScript>() != null)
            {
                col.GetComponentInChildren<PivotScript>().transform.localScale = Vector3.one;
            }
        }
    }

    void OMU()
    {
        Debug.Log("coucou");
        if (isAttached)
        {
            return;
        }

        if (ObjectOnTrigger == false)
        {
            Debug.Log("Destroy that object");
            UIManager.GetComponent<Parts_GUI_Manager_Script>().AnObjectIsSelected = false;
            Destroy(gameObject);
            return;
        }
        else
        {
            UIManager.GetComponent<Parts_GUI_Manager_Script>().DropObject(Pivot.transform);
        }

    }
}
