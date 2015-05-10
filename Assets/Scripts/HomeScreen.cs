using UnityEngine;
using UnityEngine.UI;

public class HomeScreen : MonoBehaviour {

	public Text startText;
	public GameObject restart;

	// Use this for initialization
	void Start ()
	{
		if (PlayerPrefs.HasKey("brains"))
		{
            startText.text = "CONTINUE";
			restart.SetActive(true);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void DeleteSave()
	{
		PlayerPrefs.DeleteAll();
	}
	public void GoToEditor()
	{
		Application.LoadLevel(0);
	}
}
