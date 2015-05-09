using UnityEngine;
using System.Collections;

public class LegBehavior_2 : Lamb {

	private float speedExtend = 12.0f;
	private float speedRetract = 20.0f;


	public GameObject piston;
	public GameObject foot;
	public bool IsOnFloor;
	private GameObject player;

	private float maxYPiston;
	private Vector3 firstPos;
	private float speed;
	private float coolDown = 0;


	void Start(){
		maxYPiston = 2.0f;
		player = GameObject.Find("Player");
	}

	void Update () {

		if(coolDown > 0)
			coolDown -= Time.deltaTime;

		IsOnFloor = foot.GetComponent<FootTestCollision>().IsOnFloor;


		if(Input.GetKey(KeyCode.Space)){

			if(piston.transform.localPosition.y < maxYPiston){

				piston.transform.localPosition = new Vector3(piston.transform.localPosition.x, piston.transform.localPosition.y + Time.deltaTime * speedExtend, piston.transform.localPosition.z);
				if(IsOnFloor && coolDown <= 0){
					coolDown = 0.1f;
					player.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 800));
				}
			} 
		}
		else if(piston.transform.localPosition.y > 0.1f){
			piston.transform.localPosition = new Vector3(piston.transform.localPosition.x, piston.transform.localPosition.y + Time.deltaTime * speedRetract, piston.transform.localPosition.z);
		}
	}
}
