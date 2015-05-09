using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LambsManager : MonoBehaviour 
{
	public List<GameObject> pivots;

	public GameObject selectedLamb;
	public GameObject particlePrefab;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if ( selectedLamb == null )
		{

		}
		else
		{
			if( Input.GetKeyDown(KeyCode.W) ) 
			{
				GameObject lamb = GameObject.Instantiate( selectedLamb, Vector2.zero, Quaternion.identity ) as GameObject;
				AttachLamb(lamb, pivots[0].transform);
			}
			if( Input.GetKeyDown(KeyCode.X) ) 
			{
				GameObject lamb = GameObject.Instantiate( selectedLamb, Vector2.zero, Quaternion.identity ) as GameObject;
				AttachLamb(lamb, pivots[1].transform);
			}
			if( Input.GetKeyDown(KeyCode.C) ) 
			{
				GameObject lamb = GameObject.Instantiate( selectedLamb, Vector2.zero, Quaternion.identity ) as GameObject;
				AttachLamb(lamb, pivots[2].transform);
			}
			if( Input.GetKeyDown(KeyCode.V) ) 
			{
				GameObject lamb = GameObject.Instantiate( selectedLamb, Vector2.zero, Quaternion.identity ) as GameObject;
				AttachLamb(lamb, pivots[3].transform);
			}
		}

	}

	void AttachLamb( GameObject lamb, Transform pivot )
	{
		lamb.transform.parent = pivot;
		lamb.transform.localPosition = selectedLamb.transform.localPosition;
		lamb.transform.localRotation = Quaternion.identity;

		gameObject.AddComponent<HingeJoint2D>();
		GetComponent<HingeJoint2D>().connectedBody = lamb.GetComponent<Rigidbody2D>();
		GetComponent<HingeJoint2D>().anchor = pivot.transform.localPosition;
		GetComponent<HingeJoint2D>().connectedAnchor = lamb.transform.localPosition;
		GetComponent<HingeJoint2D>().useLimits = true;

		JointAngleLimits2D limits = GetComponent<HingeJoint2D>().limits;
		limits.min = lamb.GetComponent<Lamb>().angleMin;
		limits.max = lamb.GetComponent<Lamb>().angleMax;
		GetComponent<HingeJoint2D>().limits = limits;
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		Debug.Log(GetComponent<Rigidbody2D>().velocity.magnitude);
		if( GetComponent<Rigidbody2D>().velocity.magnitude < 0.2)
		{
			for (int i = 0; i < Random.Range(5, 10); i++)
			{
				Vector3 pos = collision.contacts[0].point;
				GameObject particle = GameObject.Instantiate(particlePrefab, pos, Quaternion.identity) as GameObject;
				particle.GetComponent<Rigidbody2D>().AddTorque(1, ForceMode2D.Impulse);
				particle.GetComponent<Rigidbody2D>().AddForce(new Vector2( -5 + Random.value * 10, Random.value * 10) , ForceMode2D.Impulse);
			}
		}
	}
}
