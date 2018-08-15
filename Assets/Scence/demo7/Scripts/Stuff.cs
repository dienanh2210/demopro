using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Stuff : MonoBehaviour {
	public Rigidbody Body { get; private set; }

	void Awake () {
		Body = GetComponent<Rigidbody>();
	}
	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag =="killzone") {
			gameObject.SetActive (false);
			//Destroy (gameObject);
		}
	}
}