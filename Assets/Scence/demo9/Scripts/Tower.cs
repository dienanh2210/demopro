using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {
	public GameObject bulletPrefab;
	GameObject target;
	// Use this for initialization

	// Rotation Speed
	public float rotationSpeed = 35;

	void Update() {
		transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed, Space.World);
	}
	void OnTriggerEnter(Collider co) {
		//int i = 1;
		// Was it a Monster? Then Shoot it
		if (co.GetComponent<Monster> ()) 
		{
			if(co.gameObject !=target){

				target = co.gameObject;
				GameObject g = (GameObject)Instantiate (bulletPrefab, transform.position, Quaternion.identity);
				g.GetComponent<Bullet> ().target = co.transform;
				Destroy (g, 1);
			}
		
		}
			
	}
}
