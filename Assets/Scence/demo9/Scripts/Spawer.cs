using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawer : MonoBehaviour {

	// Use this for initialization
	public GameObject pref;
	public Transform bg;
	void Start () {
		createMap();

	}

	// Update is called once per frame
	void Update () {

	}
	void createMap()
	{
		for(int x = 0; x < 29; x++)
		{
			for (int y = 0; y <30; y++)
			{
				GameObject ob = (GameObject)Instantiate(pref,bg);
				ob.transform.localPosition = new Vector3(-14,0.5f,-14) + new Vector3(x,0,y);
			}
		}
	}
}