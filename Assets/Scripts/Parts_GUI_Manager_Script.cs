using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Parts_GUI_Manager_Script : MonoBehaviour {

    public Sprite[] PartsSprites;
    public Button ButtonPrefab;
    public GameObject Parent;
    float n;
    float ButtonScale;
    float x;
    int NumberOfParts;
    float ScreenHeight;
    float ScreenWidth;

	// Use this for initialization
	void Start()
    { 
        SpawnUI();
	}

    public void SpawnUI()
    {
        ScreenHeight = Parent.GetComponent<RectTransform>().sizeDelta.y;
        ScreenWidth = Parent.GetComponent<RectTransform>().sizeDelta.x;
        x = ScreenWidth * 0.9f;
        NumberOfParts = PartsSprites.Length;
        Button[] ButtonArray = new Button[NumberOfParts];
        n = ScreenHeight / (NumberOfParts + 3);
        ButtonScale = (n);
        for (int i = 0; i < NumberOfParts; i++)
        {
            float y;
            y = ScreenHeight - (n * 1.5f) - ((n + n / (NumberOfParts - 1)) * i);
            ButtonArray[i] = Instantiate(ButtonPrefab, new Vector3(0, 0, 0), Quaternion.identity) as Button;
            ButtonArray[i].transform.SetParent(Parent.transform, false);
            ButtonArray[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(x - ScreenWidth / 2, y - ScreenHeight / 2);
            ButtonArray[i].GetComponent<RectTransform>().sizeDelta = new Vector3(ButtonScale, ButtonScale, 1);
            ButtonArray[i].GetComponent<Image>().sprite = PartsSprites[i];
            ButtonArray[i].GetComponent<ButtonScript>().SerialNumber = i;
        }
    }

    public void GrabPart(int i) //parties du corps de 0 à i
    {
        //faire la fonction drag and drop en fonction de i
    }
}
