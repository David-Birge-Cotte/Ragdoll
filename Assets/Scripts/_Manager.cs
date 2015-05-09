using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class _Manager : MonoBehaviour {

	public int Score;	
	public Text ScoreUI;

	void Update () 
	{
		ScoreUI.text = "Score : " + Score.ToString();
	}

	public void restartLevel()
	{
		Debug.Log("Restart level");
		Application.LoadLevel(Application.loadedLevel);
	}
}
