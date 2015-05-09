using UnityEngine;
using System.Collections;

public class EndLevel : MonoBehaviour {

	//private _Manager manager;

	void Start () {
		//manager = GameObject.Find("_Manager").GetComponent<_Manager>();
	}

	void OnTriggerEnter2D (Collider2D other) 
	{
		if(other.tag != "Plateform")
		{
			Application.LoadLevel(0);
			Destroy(GameObject.Find("Player").gameObject);
		}
	}
}
