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

		HingeJoint2D hinge = gameObject.AddComponent<HingeJoint2D>();
		hinge.connectedBody = lamb.GetComponent<Rigidbody2D>();
		hinge.anchor = pivot.transform.localPosition;
		hinge.connectedAnchor = lamb.transform.localPosition;
		hinge.useLimits = true;

		JointAngleLimits2D limits = GetComponent<HingeJoint2D>().limits;
		limits.min = lamb.GetComponent<Lamb>().angleMin;
		limits.max = lamb.GetComponent<Lamb>().angleMax;
		hinge.limits = limits;
	}

}
