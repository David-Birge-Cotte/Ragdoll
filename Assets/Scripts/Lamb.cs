using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Lamb : MonoBehaviour 
{
	public float angleMin;
	public float angleMax;
	public Vector3 offset;
	public string userKey;
	public List<AudioClip> SFX;
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "ADN")
        {
            collider.GetComponent<AudioSource>().Play();
            FindObjectOfType<_Manager>().AddADN(collider.gameObject);
            collider.enabled = false;
        }
        else if (collider.tag == "Brain")
        {
            FindObjectOfType<_Manager>().AddBrain(collider.gameObject);
            collider.enabled = false;
        }
    }
}
