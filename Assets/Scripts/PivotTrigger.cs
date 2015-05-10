using UnityEngine;
using System.Collections;
using DG.Tweening;

public class PivotTrigger : MonoBehaviour {

    GameObject UIManager;
    GameObject pivotToBeAttached;
	// Use this for initialization
	void Start () 
    {
		UIManager = GameObject.Find("UIManager");
		Debug.Log( UIManager.name );
	}

	void Reset () 
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
            if (col.transform.childCount > 1)
                return;

            pivotToBeAttached = col.gameObject;
            col.GetComponentInChildren<PivotScript>().transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutQuart);
        }

       
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Pivot")
        {
            pivotToBeAttached = null;
            col.GetComponentInChildren<PivotScript>().transform.DOScale(new Vector3(0.5f,0.5f,0.5f), 0.5f).SetEase(Ease.OutQuart);
        }
    }
}
