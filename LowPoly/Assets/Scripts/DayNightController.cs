using UnityEngine;
using System.Collections;

public class DayNightController : MonoBehaviour {

    // The directional light which we manipulate as our sun.
	public Light sun, moonLight;
	public GameObject water, moonSphere;
	public Material waterMaterial, starMaterial;
    // The number of real-world seconds in one full game day.
    // Set this to 86400 for a 24-hour realtime day.
    public float secondsInFullDay = 120f;
	public Color waterColor =  new Color(0.12f,0.12f,0.12f,0.5f);
	public float r = 94.0f, g = 118.0f, b = 156.0f, a = 0.0f;

    // The value we use to calculate the current time of day.
    // Goes from 0 (midnight) through 0.25 (sunrise), 0.5 (midday), 0.75 (sunset) to 1 (midnight).
    // We define ourself what value the sunrise sunrise should be etc., but I thought these 
    // values fit well. And now much of the script are hardcoded to these values.
    [Range(0,1)]
    public float currentTimeOfDay = 0;

    // A multiplier other scripts can use to speed up and slow down the passing of time.
    [HideInInspector]
    public float timeMultiplier = 1f;

    // Get the initial intensity of the sun so we remember it.
	float sunInitialIntensity, moonLightInitialIntensity;
    void Start() {
        sunInitialIntensity = sun.intensity;
		moonLightInitialIntensity = moonLight.intensity;

		//float lerp = Mathf.PingPong(Time.time, 1.0f) / 1.0f;
		//water.GetComponent<Renderer>().material.color = Color.Lerp(Color.green, Color.green, lerp);
		//waterMaterial.color = new Color (0.1f, 0.1f, 0.1f);
		//water.GetComponent<Renderer>().material.color = Color.red;
		//waterMaterial.SetColor ("_BaseColor", Color.red);
    }

    void Update() {
        // Updates the sun's rotation and intensity according to the current time of day.
        UpdateSun();

        // This makes currentTimeOfDay go from 0 to 1 in the number of seconds we've specified.
        currentTimeOfDay += (Time.deltaTime / secondsInFullDay) * timeMultiplier;

        // If currentTimeOfDay is 1 (midnight) set it to 0 again so we start a new day.
        if (currentTimeOfDay >= 1) {
            currentTimeOfDay = 0;


        }
    }

    void UpdateSun() {
		//water.GetComponent<Renderer> ().material = waterMaterial;
        // Rotate the sun 360 degrees around the x-axis according to the current time of day.
        // We subtract 90 degrees from this to make the sun rise at 0.25 instead of 0.
        // I just found that easier to work with.
        // The y-axis determines where on the horizon the sun will rise and set.
        // The z-axis does nothing.
        sun.transform.localRotation = Quaternion.Euler((currentTimeOfDay * 360f) - 90, 170, 0);
		moonLight.transform.localRotation = Quaternion.Euler((currentTimeOfDay * 360f) -90, -170, 0);
		moonSphere.transform.localRotation = Quaternion.Euler((currentTimeOfDay * 360f) -90, -170, 0);
		moonSphere.transform.RotateAround (Vector3.zero, Vector3.right, currentTimeOfDay);

        // The following determines the sun's intensity according to current time of day.
        // You'll notice I have hardcoded a bunch of values here. They were just the values
        // I felt worked best. This can obviously be made to be user configurable.
        // Also with some more clever code you can have different lengths for the day and
        // night as well.

		// The value we use to calculate the current time of day.
		// Goes from 0 (midnight) through 0.25 (sunrise), 0.5 (midday), 0.75 (sunset) to 1 (midnight).

		float fogChangeSpeed = 1000 * secondsInFullDay;

		//DayTime, lightup fogcolor
		if (currentTimeOfDay > 0.23f && currentTimeOfDay < 0.75f) 
		{

			if(r < 1.0f/255.0f*94.0f)
				r += 94.0f/fogChangeSpeed;
			if(g < 1.0f/255.0f*118.0f)
				g += 118.0f/fogChangeSpeed;
			if(b < 1.0f/255.0f*156.0f)
				b += 156.0f/fogChangeSpeed;
			if(a > 0.0f)
				a -= 1.0f / secondsInFullDay ;
			
			//starMaterial.color = new Color (1.0f,1.0f, 1.0f, a);
			Color starColor =  new Color(1.0f,1.0f,1.0f,a);
			starMaterial.SetColor("_TintColor", starColor);

			Debug.Log (1.0f/255.0f*94.0f + ":" + 1.0f/255.0f*118.0f + ":"  + 1.0f/255.0f*156.0f);
			RenderSettings.fogColor = new Color(r,g,b,a);
			RenderSettings.fog = true;
		}

        // The sun is full intensity during the day.
        float intensityMultiplier = 1;
        // Set intensity to 0 during the night night.
        if (currentTimeOfDay <= 0.23f || currentTimeOfDay >= 0.75f) {
            intensityMultiplier = 0.1f;
			//waterMaterial.SetColor ("_BaseColor", Color.black);

			//NightTime, darken fogcolor
			if(r > 0.0f)
				r -= 94.0f/fogChangeSpeed;
			if(g > 0.0f)
				g -= 118.0f/fogChangeSpeed;
			if(b > 0.0f)
				b -= 156.0f/fogChangeSpeed;
			if(a < 1.0f)
				a += 0.1f / secondsInFullDay;	
			//starMaterial.color = new Color (1.0f,1.0f, 1.0f, a);
			Color starColor =  new Color(1.0f,1.0f,1.0f,a);
			starMaterial.SetColor("_TintColor", starColor);

			RenderSettings.fogColor = new Color(r,g,b,a);
			RenderSettings.fog = true;
        }
        // Fade in the sun when it rises.
        else if (currentTimeOfDay <= 0.25f) {
            // 0.02 is the amount of time between sunrise and the time we start fading out
            // the intensity (0.25 - 0.23). By dividing 1 by that value we we get get 50.
            // This tells us that we have to fade in the intensity 50 times faster than the
            // time is passing to be able to go from 0 to 1 intensity in the same amount of
            // time as the currentTimeOfDay variable goes from 0.23 to 0.25. That way we get
            // a perfect fade.
            intensityMultiplier = Mathf.Clamp01((currentTimeOfDay - 0.23f) * (1 / 0.02f));
			//waterMaterial.SetColor ("_BaseColor", dayColor);

        }
        // And fade it out when it sets.
        else if (currentTimeOfDay >= 0.73f) {
            intensityMultiplier = Mathf.Clamp01(1 - ((currentTimeOfDay - 0.73f) * (1 / 0.02f)));
			//waterMaterial.SetColor ("_BaseColor", Color.blue);
			//waterMaterial.SetColor ("_BaseColor", waterColor);
        }

        // Multiply the intensity of the sun according to the time of day.
        sun.intensity = sunInitialIntensity * intensityMultiplier;
    }
}