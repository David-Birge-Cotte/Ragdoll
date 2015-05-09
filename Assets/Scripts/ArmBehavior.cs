using UnityEngine;
using System.Collections;

public class ArmBehavior : Lamb
{
	public bool inverted = false;
	public float force = 25;
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKey("a"))
		{
			if(inverted)
				GetComponent<Rigidbody2D>().AddTorque(force,ForceMode2D.Impulse);
			else
				GetComponent<Rigidbody2D>().AddTorque(-force,ForceMode2D.Impulse);
		}
		if (Input.GetKeyUp( KeyCode.A ))
			inverted = !inverted;
	}
}
