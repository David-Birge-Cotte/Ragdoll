using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

	public AnimationState anim;
	public bool isActive;

	static Checkpoint lastActive;

	public void SetCheckpointActive()
	{
		GetComponent<Animator>().speed = 1;
		lastActive.SetCheckpointDesactive();
		isActive = true;
		lastActive = this;
	}
	public void SetCheckpointDesactive()
	{
		GetComponent<Animator>().speed = 0;
		anim.time = 0;
		isActive = false;
	}
}
