using UnityEngine;
using System.Collections;

public class Smoke : MonoBehaviour {

	public float speed = 1.0f;

	// Use this for initialization
	void Start () {
		transform.Rotate ( Random.Range (0, 360), 0 , Random.Range (0, 360));			
			StartCoroutine (Wait ()); 	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
	}

	IEnumerator Wait ()
	{
			yield return new WaitForSeconds (3.0f);
		Destroy (gameObject);
	}
}
