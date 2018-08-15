using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hours : MonoBehaviour {

	// Use this for initialization
	int numObjects = 12;
	[SerializeField]
	List<Text> prefab=new List<Text>();

	void Start()
	{
		Vector3 center = transform.position;
		for (int i = 0; i < numObjects; i++)
		{
			int a = i * 30;
			Vector3 pos = RandomCircle(center, 200f ,a);
			prefab [i].transform.localPosition = pos;
		}
	}
	Vector3 RandomCircle(Vector3 center, float radius,int a)
	{
		Debug.Log(a);
		float ang = a;
		Vector3 pos;
		pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
		pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
		pos.z = center.z;
		return pos;
	}
}
