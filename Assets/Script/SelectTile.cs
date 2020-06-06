using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class SelectTile : MonoBehaviour
{
	private Main main;
	private Combat combat;

	// Use this for initialization
	void Start()
	{
		combat = GameObject.FindObjectOfType<Combat>();
		main = GameObject.FindObjectOfType<Main>(); 
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButtonDown(1))
		{
			Debug.Log("Right");
			main.MovetoTile();
		}
	}

	void OnMouseDown()
	{
		if (!combat.combat)
		{
			if (Input.GetMouseButtonDown(0))
			{
				main.SelectTile();
				GameObject.FindObjectOfType<Amount>().changedAmount();
			}
		}
	}
}
