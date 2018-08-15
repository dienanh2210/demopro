using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	// The TextMesh Component
	public TextMesh tm;

	// Use this for initialization
	void Start () {
	//	tm = GetComponent<TextMesh>();
	}

	// Update is called once per frame
	void Update () {
		transform.forward = Camera.main.transform.forward;
	}
	public int current() {
		if(!tm)
			tm = GetComponent<TextMesh>();
		return tm.text.Length;
	}

	// Decrease the current Health by removing one '-'
	public void decrease() {
		if (current() > 1)
			tm.text = tm.text.Remove(tm.text.Length - 1);
		else
			Destroy(transform.parent.gameObject);
	}
}