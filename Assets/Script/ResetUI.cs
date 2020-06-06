using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class ResetUI : MonoBehaviour {

	public GameObject Arrow;
	public GameObject MilitaryUI; 
	private Vector2 screenBounds;
	private MapUI mapUI;
	private Combat combat;

	// Use this for initialization
	void Start () {

		combat = GameObject.FindObjectOfType<Combat>();
		screenBounds = GameObject.FindObjectOfType<Main>().screenBounds;
		mapUI = GameObject.FindObjectOfType<MapUI>();

	}
	
	public void Reset()
	{

		if (!combat.combat)
		{
			Arrow.GetComponent<Transform>().position = new Vector3(-screenBounds.x, -screenBounds.y, 0);
			MilitaryUI.GetComponent<Transform>().position = new Vector3(-screenBounds.x, -screenBounds.y, 0);
			mapUI.trops.GetComponent<Transform>().position = new Vector3(-screenBounds.x, -screenBounds.y, 0);
		}
	}
}
