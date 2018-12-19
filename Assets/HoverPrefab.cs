using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverPrefab : MonoBehaviour
{

	private bool isInside;
	private Vector3[] corners;
	private RectTransform rt;
	private RectTransform prt;
	private Vector3 localSpacePoint;

    // Start is called before the first frame update
    public void Awake()
    {
        corners = new Vector3[4];
        rt = GetComponent<RectTransform>();
        prt = GameObject.Find("Canvas").GetComponent<RectTransform>();
    }

	void Update ()
	{
		isInside = true;

		// corners of item in world space
		rt.GetWorldCorners(corners);

		for (int i = 0; i < 4; i++)
		{
			// Backtransform to parent space
			localSpacePoint = prt.InverseTransformPoint(corners[i]);

			// If parent (canvas) does not contain checked items any point
			if (prt.rect.Contains(localSpacePoint) ==  false)
			{
		  		isInside = false;
			}
		}

		Debug.Log(isInside);
	} 
}
