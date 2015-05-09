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
		foreach( PivotScript ps in FindObjectsOfType<PivotScript>() )
			Destroy( ps.gameObject );
		foreach( BindToLamb ps in FindObjectsOfType<BindToLamb>() )
			Destroy( ps.gameObject );
		foreach( PivotTrigger pt in FindObjectsOfType<PivotTrigger>() )
			Destroy( pt );
		foreach( LambsManager ps in FindObjectsOfType<LambsManager>() )
			Destroy( ps );
		
    	player.transform.position = startPos;
    	player.GetComponent<Rigidbody2D>().isKinematic = false;
        Application.LoadLevel(i);
    }
}
