using UnityEngine;
using System.Collections;

public class LegBehavior_2 : MonoBehaviour {

	private float speedExtend = 3.0f;
	private float speedRetract = 7.0f;


	public GameObject piston;
	public GameObject foot;
	public bool IsOnFloor;
	private GameObject player;

	private float maxYPiston;
	private Vector3 firstPos;
	private float speed;
	private float coolDown = 0;


	void Start(){
		maxYPiston = -0.712f;
		player = GameObject.Find("Player");
	}

	void Update () {

		if(coolDown > 0)
			coolDown -= Time.deltaTime;

		IsOnFloor = foot.GetComponent<FootTestCollision>().IsOnFloor;


		if(Input.GetKey(KeyCode.Space)){

			if(piston.transform.localPosition.y > maxYPiston){

				piston.transform.localPosition = new Vector3(piston.transform.localPosition.x, piston.transform.localPosition.y - Time.deltaTime * speedExtend, piston.transform.localPosition.z);
				if(IsOnFloor && coolDown <= 0){
					coolDown = 0.1f;
					player.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 500));
				}
			} 
		}
		else if(piston.transform.localPosition.y < -0.1f){
			piston.transform.localPosition = new Vector3(piston.transform.localPosition.x, piston.transform.localPosition.y + Time.deltaTime * speedRetract, piston.transform.localPosition.z);
		}
	}
}
