using UnityEngine;
using System.Collections;

public class ArmBehavior : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.A))
		{
			GetComponent<Rigidbody2D>().AddTorque(2,ForceMode2D.Impulse);
		}
	}
}
