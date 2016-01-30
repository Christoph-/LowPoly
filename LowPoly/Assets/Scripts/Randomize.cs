using UnityEngine;
using System.Collections;

public class Randomize : MonoBehaviour {
		 
	float scaleFactor = 100.0f, scaleFactorOld = 0.0f;
	float scaleFactorCloud = 2.0f;
	float scaleFactorTree = 0.4f;

	float cloudTransparency = 0.0f;
	public Material cloudMaterial;

	// Use this for initialization
	void Start () {


		if (gameObject.tag == "Cloud") {

			transform.Rotate (270,270,180);
			//transform.Rotate (Random.Range (0, 360), Random.Range (0, 360), Random.Range (0, 360));
			Debug.Log ("Cloud");

			StartCoroutine (Wait ()); 
		}
		if (gameObject.tag == "Tree") {
			transform.Rotate (0, Random.Range (0, 360), 0);
			transform.localScale = new Vector3(Random.Range (scaleFactorTree, scaleFactorTree*2), Random.Range (scaleFactorTree, scaleFactorTree*2), Random.Range (scaleFactorTree, scaleFactorTree*2));
			Debug.Log ("Tree");
			
		}
		if (gameObject.tag == "Stone") {
			transform.Rotate (Random.Range (0, 360), Random.Range (0, 360), Random.Range (0, 360));
			transform.localScale = new Vector3(Random.Range (100.0f, 200.0f), Random.Range (100.0f, 200.0f), Random.Range (100.0f, 200.0f));
			Debug.Log ("Stone");

			}
	}

	IEnumerator Wait ()
	{
		scaleFactorCloud = Random.Range (192, 384);
		for(scaleFactor = 1.0f; scaleFactor < scaleFactorCloud; scaleFactor += scaleFactorOld)
		{	
			scaleFactorOld += 0.5f;
			transform.localScale = new Vector3(scaleFactor*2,scaleFactor*4, scaleFactor*2);

			cloudMaterial.color = new Color (1.0f,1.0f, 1.0f, cloudTransparency);
			cloudTransparency += 0.02f;

			yield return new WaitForSeconds (0.0f);
		}

	}
}
