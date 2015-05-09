using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour 
{
	public GameObject player;
	public Vector3 startPos;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadLevel(int i)
    {
    	player.transform.position = startPos;
    	player.GetComponent<Rigidbody2D>().isKinematic = false;
        Application.LoadLevel(i);
    }
}
