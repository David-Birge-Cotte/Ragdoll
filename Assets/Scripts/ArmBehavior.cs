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
			{
				GetComponent<Rigidbody2D>().AddTorque(force,ForceMode2D.Impulse);
			}
			else
			{
				if ( !GetComponent<AudioSource>().isPlaying )
				{
					GetComponent<AudioSource>().clip = SFX[ 1 ];
					GetComponent<AudioSource>().Play();
				}
				GetComponent<Rigidbody2D>().AddTorque(-force,ForceMode2D.Impulse);
			}
		}

		if (Input.GetKeyUp( KeyCode.A ))
			inverted = !inverted;
		if(Input.GetKeyDown(KeyCode.A))
			GetComponent<AudioSource>().PlayOneShot(SFX[ Random.Range(0, 1) ]);
	}
}
