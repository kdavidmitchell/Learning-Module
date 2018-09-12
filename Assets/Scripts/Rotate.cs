using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Rotate : MonoBehaviour 
{
	public float speed = 10f;

	private void OnMouseDrag()
	{
		Debug.Log("Dragging");
		float x = Input.GetAxis("Mouse X") * speed * Mathf.Deg2Rad;
		gameObject.transform.RotateAround(Vector3.down, x);

		//float y = Input.GetAxis("Mouse Y") * speed * Mathf.Deg2Rad;
		//gameObject.transform.RotateAround(Vector3.right, y);
	}
}
