using UnityEngine;
using System.Collections;

public class CloudSpawner : MonoBehaviour {

	public GameObject Cloud, Cloud2 , Cloud3, Star;
	
	// Use this for initialization
	void Start () {
		StartCoroutine (SpawnCloud ());

		for (int i = 0; i < 20; i++) {
			Instantiate (Cloud, transform.position = new Vector3 (Random.Range (-256, 256), Random.Range (96, 128), Random.Range (-256, 256)), Cloud.transform.rotation);
		}
		for (int i = 0; i < 20; i++) {
			Instantiate (Cloud2, transform.position = new Vector3 (Random.Range (-256, 256), Random.Range (96, 128), Random.Range (-256, 256)), Cloud2.transform.rotation);
		}
		for (int i = 0; i < 20; i++) {
			Instantiate (Cloud3, transform.position = new Vector3 (Random.Range (-256, 256), Random.Range (96, 128), Random.Range (-256, 256)), Cloud3.transform.rotation);
		}

		int area = 1024;

		for (int i = 0; i < 2000; i++) {
			Instantiate (Star, transform.position = new Vector3 (Random.Range (-area, area), 192, Random.Range (-area, area)), Star.transform.rotation);
		}
	}
		
	IEnumerator SpawnCloud ()
	{
		while (true) {
			yield return new WaitForSeconds (Random.Range (20, 40));
			Debug.Log ("Cloud Spawned");
			Instantiate (Cloud, transform.position = new Vector3 (-256, Random.Range (64, 128), Random.Range (-256, 256)), Cloud.transform.rotation);
			Instantiate (Cloud2, transform.position = new Vector3 (-256, Random.Range (64, 128), Random.Range (-256, 256)), Cloud2.transform.rotation);
			Instantiate (Cloud3, transform.position = new Vector3 (-256, Random.Range (64, 128), Random.Range (-256, 256)), Cloud3.transform.rotation);
		}
	}
}
