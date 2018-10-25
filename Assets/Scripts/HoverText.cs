using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler 
{

	public GameObject hoverTextPrefab;
	public string definition;
	private GameObject instance;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		instance = Instantiate(hoverTextPrefab, Input.mousePosition, Quaternion.identity);
		instance.transform.SetParent(transform, false);
		Text definitionText = GameObject.Find("Definition").GetComponent<Text>();
		definitionText.text = definition;
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		Destroy(instance);
	}
}
