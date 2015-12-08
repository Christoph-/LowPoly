using UnityEngine;
using System.Collections;

public class RotatingSun : MonoBehaviour
{
	public float RotatingSpeed = 1;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Slowly rotate the object around its X axis at 1 degree/second.
		transform.Rotate (Vector3.right * RotatingSpeed * Time.deltaTime);
		
		// ... at the same time as spinning relative to the global 
		// Y axis at the same speed.
		//transform.Rotate (Vector3.up * RotatingSpeed * Time.deltaTime, Space.World);
	}
}
