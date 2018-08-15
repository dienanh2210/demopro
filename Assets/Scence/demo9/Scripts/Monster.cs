using UnityEngine;
using System.Collections;
using UnityEngine.AI;
public class Monster : MonoBehaviour {
	//public Transform castle;
	// Use this for initialization
/*	void Start () {
		
		GameObject castle = GameObject.Find("Castle");
		if (castle)
			GetComponent<NavMeshAgent>().destination = castle.transform.position;
		
	}*/
	public Transform goal;

	void Start () {
		NavMeshAgent agent = GetComponent<NavMeshAgent>();
		agent.destination = goal.position; 
	}
	void OnTriggerEnter(Collider co) {
		// If castle then deal Damage, destroy self

		if (co.tag == "abc") 
		{
			Debug.Log (1111);
			co.transform.GetChild(0).GetComponent<Health>().decrease();
			Destroy(gameObject);
		}
	// Update is called once per frame

//		Health health = co.GetComponentInChildren<Health>();
//		if (health) {
//			health.decrease();
//			Destroy(gameObject);
//		}
	}
}