using UnityEngine;
using System.Collections;

public class ArmBehavior : MonoBehaviour 
{
	public bool DroiteOuGauche;



	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if(Input.GetKeyDown(KeyCode.A))
		{

			if(DroiteOuGauche) //Droite
				GetComponent<Rigidbody2D>().AddTorque(2,ForceMode2D.Impulse);
			else if (!DroiteOuGauche) //gauche
				GetComponent<Rigidbody2D>().AddTorque(-2,ForceMode2D.Impulse);
		}
	}
}
