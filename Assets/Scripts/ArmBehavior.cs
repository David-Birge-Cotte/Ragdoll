using UnityEngine;
using System.Collections;

public class ArmBehavior : Lamb
{
	public bool inverted = false;
	public float force = 15;

	void Start()
	{
		userKey = "x";
	}

	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKey(userKey))
		{
			if(inverted)
			{
				GetComponent<Rigidbody2D>().AddTorque(force,ForceMode2D.Impulse);
			}
			else
			{
				GetComponent<Rigidbody2D>().AddTorque(-force,ForceMode2D.Impulse);
			}
		}
		if (Input.GetKeyUp(userKey))
			inverted = !inverted;
		if(Input.GetKeyDown(userKey))
			GetComponent<AudioSource>().PlayOneShot(SFX[ Random.Range(0, 1) ]);
	}
}
