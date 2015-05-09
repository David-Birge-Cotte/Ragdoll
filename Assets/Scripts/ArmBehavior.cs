using UnityEngine;
using System.Collections;

public class ArmBehavior : Lamb
{
	public bool LeftOrRight;
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKey(KeyCode.A))
		{

			if(LeftOrRight){
				GetComponent<Rigidbody2D>().AddTorque(5,ForceMode2D.Impulse);
			}
			else{
				GetComponent<Rigidbody2D>().AddTorque(-5,ForceMode2D.Impulse);
			}
		}
	}
}
