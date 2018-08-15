using UnityEngine;
public class StuffSpawner : MonoBehaviour {
	//public float timeBetweenSpawns;
	public Stuff[] stuffPrefabs;
	float timeSinceLastSpawn;
	public float velocity;


	public FloatRange timeBetweenSpawns, scale, randomVelocity,angularVelocity;
	float currentSpawnDelay;
	public Material stuffMaterial;
	[System.Serializable]
	public struct FloatRange {
		public float min, max;

		public float RandomInRange {
			get {
				return Random.Range(min, max);
			}
		}
	}

/*	void FixedUpdate () {
		timeSinceLastSpawn += Time.deltaTime;
		if (timeSinceLastSpawn >= timeBetweenSpawns) {
			timeSinceLastSpawn -= timeBetweenSpawns;
			SpawnStuff();
		}
	}*/
	void FixedUpdate () {
		timeSinceLastSpawn += Time.deltaTime;
		if (timeSinceLastSpawn >= currentSpawnDelay) {
			timeSinceLastSpawn -= currentSpawnDelay;
			currentSpawnDelay = timeBetweenSpawns.RandomInRange;
			SpawnStuff();
		}
	}

	void SpawnStuff () {
		Stuff prefab = stuffPrefabs[Random.Range(0, stuffPrefabs.Length)];
		Stuff spawn = Instantiate<Stuff>(prefab);

		spawn.transform.localPosition = transform.position;
		spawn.transform.localScale = Vector3.one * scale.RandomInRange;
		spawn.transform.localRotation = Random.rotation;

		spawn.Body.velocity = transform.up * velocity;
		spawn.Body.velocity = transform.up * velocity +
			Random.onUnitSphere * randomVelocity.RandomInRange;
		//spawn.Body.velocity = transform.up * velocity +
		//	Random.onUnitSphere * randomVelocity.RandomInRange;
		spawn.Body.angularVelocity =
			Random.onUnitSphere * angularVelocity.RandomInRange;
		spawn.GetComponent<MeshRenderer>().material = stuffMaterial;
	}

}

