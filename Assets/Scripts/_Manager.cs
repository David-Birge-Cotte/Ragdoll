using UnityEngine;
using UnityEngine.UI;

public class _Manager : MonoBehaviour {

	static int score;
	int adnNbr;
	public Text ScoreUI, soundButton;
	public GameObject pausePanel, inGamePanel;

	GameObject player;
	Vector3 initialPlayerPos;


	void Start()
	{
		player = GameObject.Find("Player");
		initialPlayerPos = player.transform.position;
		player.GetComponent<Rigidbody2D>().isKinematic = false; //au démarage du niveau
		adnNbr = GameObject.FindGameObjectsWithTag("ADN").Length;
	}



	public void AddScore () 
	{
		score++;
		ScoreUI.text = "Score : " + score + " / " + adnNbr;
	}

	public void RestartLevel()
	{
		Debug.Log("Restart level");
		player.transform.position = initialPlayerPos;
		Application.LoadLevel(Application.loadedLevel);
	}

	public void SetPause()
	{
		Time.timeScale = 0;
		pausePanel.SetActive(true);
	}
	public void Resume()
	{
		Time.timeScale = 1;
		pausePanel.SetActive(false);
	}

	public void GoToEditor()
	{
		Destroy( player );
		//inGamePanel.SetActive(false);
		Application.LoadLevel("CharacterCreation");
	}

	bool soundActive = true;
	public void SwitchSound()
	{
		if( soundActive )
		{
			Camera.main.GetComponent<AudioSource>().mute = soundActive = false;
			soundButton.text = "Sound : OFF";
			PlayerPrefs.SetInt("Sound", 0);
		}
		else
		{
			Camera.main.GetComponent<AudioSource>().mute = soundActive = true;
			soundButton.text = "Sound : ON";
			PlayerPrefs.SetInt("Sound", 0);
		}
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
