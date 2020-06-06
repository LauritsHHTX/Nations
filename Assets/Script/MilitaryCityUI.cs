using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilitaryCityUI : MonoBehaviour {
	
	public GameObject military;
	public GameObject camera;
	private FirstCityConstructed fcc;
	private Vector2 screenBounds;
	private Vector3 camPos;
	private ResetUI resetUI;
	private Combat combat;

	// Use this for initialization
	void Start()
	{
		combat = GameObject.FindObjectOfType<Combat>();
		fcc = GameObject.FindObjectOfType<FirstCityConstructed>();
		resetUI = GameObject.FindObjectOfType<ResetUI>();
		screenBounds = GameObject.FindObjectOfType<Main>().screenBounds;
	}

	void OnMouseDown()
	{
		if (fcc.firstCity)
		{
			if (!combat.combat)
			{
				resetUI.Reset();
				military.GetComponent<Transform>().position = new Vector3(transform.position.x - screenBounds.x / 10, transform.position.y + screenBounds.y / 1.5f, transform.position.z);
			}
		}
	}
}
