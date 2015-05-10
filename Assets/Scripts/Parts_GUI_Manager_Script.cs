using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;

public class Parts_GUI_Manager_Script : MonoBehaviour 
{

    public GameObject[] Prefabs;
    public Sprite[] PartsSprites;
    public Transform[] PartsPos;
    public Button ButtonPrefab;
	GameObject[] Binds;
    int BindNumber = 0;
    public GameObject Parent;
    public GameObject BindPrefab;
    float x;
    int NumberOfParts;

    //grab
    public GameObject SelectedObject;
    public GameObject player;


    public GameObject brainValue;
    public GameObject ADNValue;
    public GameObject LimbValue;
    public int defaultNbPivots = 4;
    public int defaultNbLimbs = 3;
	private int nbCurrentLimb = 0;

	// Use this for initialization
	void Start()
    { 
		if( GameObject.FindWithTag("Player") == null )
			player = (GameObject)Instantiate(player);
        //Debug.Log(player.name);

		Binds = new GameObject[100];
        SpawnUI();

        if (PlayerPrefs.HasKey("Sound"))
        {
            if (PlayerPrefs.GetInt("Sound") == 0)
                Camera.main.GetComponent<AudioSource>().mute = true;
            else
                Camera.main.GetComponent<AudioSource>().mute = false;
        }

		/*if( GameObject.FindWithTag("Player") == null )
			player = (GameObject)Instantiate(player);*/

        if (PlayerPrefs.GetInt("currentBrains") < defaultNbPivots)
            PlayerPrefs.SetInt("currentBrains", defaultNbPivots);

        if (PlayerPrefs.GetInt("maxLimbs") < defaultNbLimbs)
            PlayerPrefs.SetInt("maxLimbs", defaultNbLimbs);

        LimbValue.GetComponent<Text>().text = nbCurrentLimb + "/" + PlayerPrefs.GetInt("maxLimbs");
        brainValue.GetComponent<Text>().text = PlayerPrefs.GetInt("currentBrains").ToString();
        ADNValue.GetComponent<Text>().text = PlayerPrefs.GetInt("currentADN").ToString();

        InitLimbPivots();
	}

    void InitLimbPivots()
    {
        //active pivots == maxLimbsPivots

        for (int i = 0; i < player.transform.childCount; i++)
        {
            player.transform.GetChild(i).gameObject.SetActive(false);
        }

        for (int i = 0; i < PlayerPrefs.GetInt("currentBrains"); i++)
		{
			player.transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    public void SpawnUI()
    {
        NumberOfParts = PartsSprites.Length;
		Button[] ButtonArray = new Button[NumberOfParts];
        for (int i = 0; i < NumberOfParts; i++)
        {
            ButtonArray[i] = Instantiate(ButtonPrefab, new Vector3(0, 0, 0), Quaternion.identity) as Button;
            ButtonArray[i].transform.SetParent(Parent.transform, false);
            ButtonArray[i].GetComponent<RectTransform>().position = PartsPos[i].position;
            ButtonArray[i].GetComponent<RectTransform>().localScale = Vector3.zero;
            ButtonArray[i].GetComponent<RectTransform>().sizeDelta = new Vector2(100, 100);
            ButtonArray[i].GetComponent<RectTransform>().DOScale(new Vector3(2, 2, 1), 1).SetEase(Ease.OutBounce);
            ButtonArray[i].GetComponent<Image>().sprite = PartsSprites[i];
            ButtonArray[i].GetComponent<ButtonScript>().SerialNumber = i;
        }
        FindObjectOfType<StartButton>().transform.localPosition = new Vector3(-1000, FindObjectOfType<StartButton>().transform.localPosition.y, 0);
        FindObjectOfType<StartButton>().transform.DOLocalMoveX(0, 1).SetEase(Ease.OutBack);
    }

    public void GrabPart(int i) //parties du corps de 0 à i
    {
        SelectedObject = Instantiate(Prefabs[i], new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        SelectedObject.GetComponent<Rigidbody2D>().isKinematic = true;
		SelectedObject.transform.localScale = Vector3.zero;
		SelectedObject.transform.DOScale(Prefabs[i].transform.localScale, 0.5f).SetEase(Ease.OutBounce);

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
		if (pivotTransform.childCount > 1 || nbCurrentLimb >= PlayerPrefs.GetInt("maxLimbs"))
		{
            LimbValue.GetComponent<Text>().DOColor(Color.red, 0.5f).OnComplete(() => { LimbValue.GetComponent<Text>().DOColor(Color.white, 2.0f); });
            Destroy(SelectedObject);
			return;
		}

		Binds[BindNumber] = Instantiate(BindPrefab);
		Binds[BindNumber].GetComponent<BindToLamb>().LinkedObject = SelectedObject.GetComponent<Lamb>();
		Binds[BindNumber].GetComponent<RectTransform>().sizeDelta = new Vector3( 1, 1, 1);
        BindNumber++;

        pivotTransform.GetComponent<AudioSource>().Play();
        SelectedObject.GetComponent<Rigidbody2D>().isKinematic = false;
        pivotTransform.GetComponentInParent<LambsManager>().AttachLamb(SelectedObject, pivotTransform);
        SelectedObject = null;
		nbCurrentLimb++;
        LimbValue.GetComponent<Text>().text = nbCurrentLimb + "/" + PlayerPrefs.GetInt("maxLimbs");
    }
    
    public void AddLimbPivot( int price )
    {
        if ( PlayerPrefs.GetInt("currentADN") >= price )
        {
            PlayerPrefs.SetInt("currentADN", PlayerPrefs.GetInt("currentADN") - price);
            PlayerPrefs.SetInt("maxLimbs", PlayerPrefs.GetInt("maxLimbs") + 1);
            ADNValue.GetComponent<Text>().text = PlayerPrefs.GetInt("currentADN").ToString();
            LimbValue.GetComponent<Text>().text = nbCurrentLimb + "/" + PlayerPrefs.GetInt("maxLimbs");
            InitLimbPivots();
        }
        else
        {
            ADNValue.GetComponent<Text>().DOColor(Color.red, 0.5f).OnComplete(() => { ADNValue.GetComponent<Text>().DOColor(Color.white, 2.0f); });
        }
    }
}
