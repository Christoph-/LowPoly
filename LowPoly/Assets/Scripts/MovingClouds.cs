using UnityEngine;
using System.Collections;

public class MovingClouds : MonoBehaviour {

	public float speed = 1f;
	float x,y,z;


	// Use this for initialization
	void Start () {
		x = transform.position.x;
		y = transform.position.y;
		z = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		x = x + speed * Time.deltaTime;
		transform.position = new Vector3 (x, y, z);
		//Debug.Log (Time.deltaTime);
	}

}
