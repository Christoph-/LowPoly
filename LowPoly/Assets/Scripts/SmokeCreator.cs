using UnityEngine;
using System.Collections;

public class SmokeCreator : MonoBehaviour {

	public GameObject Smoke;

	// Use this for initialization
	void Start () {

		StartCoroutine (Wait ()); 	
	}
	
	IEnumerator Wait ()
	{
		while (true) {
			Debug.Log (transform.position);
			Instantiate (Smoke, Smoke.transform.position = transform.position, Smoke.transform.rotation);
			yield return new WaitForSeconds (Random.Range (1, 2));
		}
	}
}
