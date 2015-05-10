using UnityEngine;
using System.Collections;

public class PivotScript : MonoBehaviour {

	public bool isDisable;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.forward * Time.deltaTime * 40);
	}
}
