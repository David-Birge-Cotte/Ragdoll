using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Parts_GUI_Manager_Script : MonoBehaviour 
{

    public GameObject[] Prefabs;
    public Sprite[] PartsSprites;
    public Button ButtonPrefab;
    Button[] Binds;
    int BindNumber = 0;
    public GameObject Parent;
    public GameObject BindPrefab;
    float n;
    float ButtonScale;
    float x;
    int NumberOfParts;
    float ScreenHeight;
    float ScreenWidth;

    //grab
    public GameObject SelectedObject;
    public GameObject Player;


	public int memberLimit = 3;

	// Use this for initialization
	void Start()
    { 
        SpawnUI();

		if( PlayerPrefs.HasKey("Score") )
		{
			memberLimit += PlayerPrefs.GetInt("Score");
		}
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

    }

    void Update()
    {
        if (SelectedObject != null)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos = new Vector3(mousePos.x, mousePos.y, 10);
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            SelectedObject.transform.position = mousePos;            
        }

        /*if (Input.GetMouseButtonDown(1))
        {
            AnObjectIsSelected = false;
            Destroy(SelectedObject);
        }*/
    }

    public void DropObject( Transform pivotTransform )
    {        
		if (pivotTransform.childCount > 1 || memberLimit == 0)
		{
			Destroy( SelectedObject );
			return;
		}

        Binds[BindNumber] = Instantiate(BindPrefab, new Vector3(0, 0, 0), Quaternion.identity) as Button;
        Binds[BindNumber].transform.SetParent(Parent.transform, false);

        Debug.Log("World to point" + Camera.main.WorldToScreenPoint(SelectedObject.transform.position));

        Binds[BindNumber].GetComponent<RectTransform>().anchoredPosition = new Vector2(Camera.main.WorldToScreenPoint(SelectedObject.transform.position).x - ScreenWidth / 2, Camera.main.WorldToScreenPoint(SelectedObject.transform.position).y - ScreenHeight / 2);
        Debug.Log("RectTransform" + (Binds[BindNumber].GetComponent<RectTransform>().anchoredPosition + new Vector2(ScreenWidth / 2, ScreenHeight / 2)));
        Binds[BindNumber].GetComponent<RectTransform>().sizeDelta = new Vector3(ButtonScale / 2, ButtonScale / 2, 1);
        Binds[BindNumber].GetComponent<BindToLamb>().SerialNumber = BindNumber;
        Binds[BindNumber].GetComponent<BindToLamb>().LinkedObject = SelectedObject;
        BindNumber++;


        pivotTransform.GetComponent<AudioSource>().Play();
        SelectedObject.GetComponent<Rigidbody2D>().isKinematic = false;
        pivotTransform.GetComponentInParent<LambsManager>().AttachLamb(SelectedObject, pivotTransform);
        SelectedObject = null;
		memberLimit--;
    }
}
