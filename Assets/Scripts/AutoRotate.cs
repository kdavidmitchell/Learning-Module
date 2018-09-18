using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotate : MonoBehaviour 
{

	private float speed = 0.5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		float x = speed * Mathf.Deg2Rad;
		gameObject.transform.RotateAround(Vector3.down, x);	
	}
}
