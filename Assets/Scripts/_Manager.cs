using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class _Manager : MonoBehaviour {
    
	public Text ADNText, soundButton;
	public GameObject pausePanel, inGamePanel;

    private int maxBrain = 6;
    private int maxADN;
    private GameObject player;
    public Vector3 initialPlayerPos;

	void Start()
	{
		player = GameObject.Find("Player");
        player.transform.position = initialPlayerPos;
		player.GetComponent<Rigidbody2D>().isKinematic = false; //au démarage du niveau
		maxADN = GameObject.FindGameObjectsWithTag("ADN").Length;
	}



	public void AddADN ()
	{
        PlayerPrefs.SetInt("currentADN", PlayerPrefs.GetInt("currentADN") + 1);
        ADNText.text = PlayerPrefs.GetInt("currentADN") + " / " + maxADN;
	}

    public void AddBrain( GameObject brain )
    {
        PlayerPrefs.SetInt("currentBrains", PlayerPrefs.GetInt("currentBrains") + 1);
        brain.transform.DOMoveY( brain.transform.position.y + 2, 1 ).SetEase(Ease.OutBounce).OnComplete( () => {
            brain.transform.DOScale(Vector3.one * 10, 5).OnComplete(() => { Application.LoadLevel(0); });
        });
    }

	public void RestartLevel()
	{
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
		Time.timeScale = 1;
		Application.LoadLevel(0);
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
