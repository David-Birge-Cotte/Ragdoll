using UnityEngine;
using System.Collections;

public class Collectible : MonoBehaviour {

	private _Manager manager;
	private bool collected = false;
	
	void Start () 
	{
		manager = GameObject.Find("_Manager").GetComponent<_Manager>();
	}

	void OnCollisionStay2D (Collision2D other) 
	{
		if (other.transform.tag != "Plateform" && collected == false)
		{
			collected = true;
			manager.Score ++;
			Destroy(transform.gameObject);
		}
	}
}