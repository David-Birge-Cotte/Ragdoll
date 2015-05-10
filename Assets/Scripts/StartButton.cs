using UnityEngine;
using System.Collections;
using DG.Tweening;

public class StartButton : MonoBehaviour 
{
	public GameObject player;
	public Vector3 startPos;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadLevel()
	{
		transform.DOMoveX(2000, 1).SetEase(Ease.InBack);
        FindObjectsOfType<ButtonScript>()[0].transform.DOScale(Vector3.zero, 1).SetEase(Ease.OutBounce);
        FindObjectsOfType<ButtonScript>()[1].transform.DOScale(Vector3.zero, 1).SetEase(Ease.OutBounce);
        FindObjectsOfType<ButtonScript>()[2].transform.DOScale(Vector3.zero, 1).SetEase(Ease.OutBounce);
        GameObject.FindWithTag("Player").transform.DOKill();
        GameObject.FindWithTag("Player").transform.DOMoveY(-10, 1.0f).SetEase(Ease.InBack).OnStepComplete(goToNextLevel);
    }

	void goToNextLevel()
	{
		foreach( PivotScript ps in FindObjectsOfType<PivotScript>() )
			Destroy( ps.gameObject );
		foreach( BindToLamb ps in FindObjectsOfType<BindToLamb>() )
			Destroy( ps.gameObject );
		foreach( PivotTrigger pt in FindObjectsOfType<PivotTrigger>() )
			Destroy( pt );
		foreach( LambsManager ps in FindObjectsOfType<LambsManager>() )
			Destroy( ps );

        Application.LoadLevel(3);
	}
}
