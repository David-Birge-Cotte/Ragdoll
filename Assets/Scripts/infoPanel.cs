using UnityEngine;
using System.Collections;
using DG.Tweening;

public class infoPanel : MonoBehaviour 
{
    private int index = 0;

	// Use this for initialization
	void Start () 
    {
        for( int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).rotation = Quaternion.Euler(new Vector3(90, 0, 0));
        }
        RotateNext(transform.GetChild(0));
	
	}

    // Update is called once per frame
    void Update()
    {
	
	}

    void RotateNext( Transform child )
    {
        transform.GetChild(index).DORotate(new Vector3(0, 0, 0), 2f).OnComplete(() =>
        {
            transform.GetChild(index).DORotate(new Vector3(90, 0, 0), 2f).OnComplete(() =>
            {
                index++;
                if (index >= transform.childCount)
                    index = 0;
                RotateNext( transform.GetChild(index) );
            });
        });

    }
}
