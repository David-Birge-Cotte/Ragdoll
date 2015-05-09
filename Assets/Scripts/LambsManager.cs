using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LambsManager : MonoBehaviour 
{
	public List<GameObject> pivots;

	public void AttachLamb( GameObject lamb, Transform pivot )
	{
		lamb.transform.parent = pivot;
		lamb.transform.localPosition = lamb.GetComponent<Lamb>().offset;
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

}
