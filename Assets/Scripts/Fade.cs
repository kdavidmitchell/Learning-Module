using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour 
{

	private Material _myMaterial;
	private Coroutine _currentFade;

	// Use this for initialization
	void Start () 
	{
		_myMaterial = GetComponent<Renderer>().material;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (_myMaterial.color.a == 0f)
		{
			_currentFade = StartCoroutine(FadeTo(_myMaterial, 1f, 3f));
		} else if (_myMaterial.color.a == 1f) 
		{
			_currentFade = StartCoroutine(FadeTo(_myMaterial, 0f, 3f));
		}	
	}

	// Define an enumerator to perform our fading.
	// Pass it the material to fade, the opacity to fade to (0 = transparent, 1 = opaque),
	// and the number of seconds to fade over.
	IEnumerator FadeTo(Material material, float targetOpacity, float duration) 
	{

		// Cache the current color of the material, and its initiql opacity.
		Color color = material.color;
		float startOpacity = color.a;

		// Track how many seconds we've been fading.
		float t = 0;

		while(t < duration) 
		{
			// Step the fade forward one frame.
			t += Time.deltaTime;
			// Turn the time into an interpolation factor between 0 and 1.
			float blend = Mathf.Clamp01(t / duration);

			// Blend to the corresponding opacity between start & target.
			color.a = Mathf.Lerp(startOpacity, targetOpacity, blend);

			// Apply the resulting color to the material.
			material.color = color;

			// Wait one frame, and repeat.
			yield return null;
		}
	}

}
