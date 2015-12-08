using UnityEngine;
using System.Collections;

public class Randomize : MonoBehaviour {
		 

	// Use this for initialization
	void Start () {
		//transform.eulerAngles  = new Vector3(0, Random.Range (0.0f, 360f), 0);
		if (gameObject.tag == "Cloud") {
			transform.Rotate (Random.Range (0, 360), Random.Range (0, 360), Random.Range (0, 360));
			transform.localScale = new Vector3(Random.Range (2000.0f, 2500.0f), Random.Range (2000.0f, 2500.0f), Random.Range (2000.0f, 2500.0f));
			Debug.Log ("Cloud");

		}
		if (gameObject.tag == "Tree") {
			transform.Rotate (0, Random.Range (0, 360), 0);
			transform.localScale = new Vector3(Random.Range (0.8f, 1.4f), Random.Range (1.0f, 1.4f), Random.Range (0.8f, 1.4f));
			Debug.Log ("Tree");
			
		}
		if (gameObject.tag == "Stone") {
			transform.Rotate (Random.Range (0, 360), Random.Range (0, 360), Random.Range (0, 360));
			transform.localScale = new Vector3(Random.Range (100.0f, 200.0f), Random.Range (100.0f, 200.0f), Random.Range (100.0f, 200.0f));
			Debug.Log ("Stone");
			
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
