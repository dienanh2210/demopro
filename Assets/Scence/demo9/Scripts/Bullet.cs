using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	// Speed
	public float speed = 10;

	// Target (set by Tower)
	public Transform target;
	// Use this for initialization
	void Start () {
		
	}
	void FixedUpdate() {    
		if (target) {
			// Fly towards the target        
			Vector3 dir = target.position - transform.position;
			GetComponent<Rigidbody>().velocity = dir.normalized * speed;
		} else {
			// Otherwise destroy self
			Destroy(gameObject,1);
		}
	}
	void OnTriggerEnter(Collider co) {
		// If castle then deal Damage, destroy self

		if (co.tag == "ab") 
		{
			Debug.Log (1111);
			co.transform.GetChild(4).GetComponent<Health>().decrease();
			Destroy(gameObject);
		}

	// Update is called once per frame
	
	}
}
