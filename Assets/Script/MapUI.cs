using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapUI : MonoBehaviour {

	public GameObject arrows;
	public GameObject camera;
	public GameObject trops;
	private FirstCityConstructed fcc;
	private Vector2 screenBounds;
	private Vector3 camPos;
	private ResetUI resetUI;
	private Main main;
	private Combat combat;

	// Use this for initialization
	void Start()
	{
		combat = GameObject.FindObjectOfType<Combat>();
		fcc = GameObject.FindObjectOfType<FirstCityConstructed>();
		resetUI = GameObject.FindObjectOfType<ResetUI>();

		main = GameObject.FindObjectOfType<Main>();	
	}


	void OnMouseDown()
	{
		if (fcc.firstCity)
		{
			if (!combat.combat)
			{
				resetUI.Reset();
				arrows.GetComponent<Transform>().position = new Vector3(transform.position.x + main.screenBounds.x / 10, transform.position.y + main.screenBounds.y / 1.5f, transform.position.z);
				trops.GetComponent<Transform>().position = new Vector3(transform.position.x + main.screenBounds.x / 3, transform.position.y + main.screenBounds.y / 1.5f, transform.position.z);
			}
		}
	}
}
