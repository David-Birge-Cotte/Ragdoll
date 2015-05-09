using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Parts_GUI_Manager_Script : MonoBehaviour {

    public GameObject[] Prefabs;
    public Sprite[] PartsSprites;
    public Button ButtonPrefab;
    public GameObject Parent;
    float n;
    float ButtonScale;
    float x;
    int NumberOfParts;
    float ScreenHeight;
    float ScreenWidth;

    //grab
    [HideInInspector]
    public bool AnObjectIsSelected = false;
    GameObject SelectedObject;
    public LambsManager _LambsManager;
    public GameObject Player;

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
        SelectedObject = Instantiate(Prefabs[i], new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        SelectedObject.GetComponent<Rigidbody2D>().isKinematic = true;
        AnObjectIsSelected = true;

    }

    void Update()
    {
        if (AnObjectIsSelected == true)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos = new Vector3(mousePos.x, mousePos.y, 10);
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            SelectedObject.transform.position = mousePos;
        }
    }

    public void DropObject(Transform ObjectTransform)
    {
        AnObjectIsSelected = false;
        SelectedObject.GetComponent<Rigidbody2D>().isKinematic = false;
        _LambsManager.AttachLamb(SelectedObject, ObjectTransform);
        ;
    }

  

}
