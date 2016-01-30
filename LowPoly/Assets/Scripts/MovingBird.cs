using UnityEngine;
using System.Collections;

public class MovingBird : MonoBehaviour {
	
	public float horizontalSpeed = 0.5f;
	public float verticalSpeed = 0.5f;
	public float amplitude = 0.5f;
	public float rotation = 20.0f;
	
	private Vector3 tempPosition, tempRotation;
	
	void Start () 
	{
		tempPosition = transform.position;
		tempRotation = transform.eulerAngles;
	}
	
	void FixedUpdate () 
	{
		tempPosition.x += horizontalSpeed;
		//tempPosition.y = Mathf.Sin(Time.realtimeSinceStartup * verticalSpeed)* amplitude;
		tempRotation.y += rotation;
		transform.position = tempPosition;
	}
}