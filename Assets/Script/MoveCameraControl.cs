using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraControl : MonoBehaviour
{
	public GameObject camera;
	private Main main;
	private Vector2 screenBounds;
	private Vector3 camPos;
	private FirstCityConstructed fcc;
	private Combat combat;

	// Use this for initialization
	void Start()
	{
		combat = GameObject.FindObjectOfType<Combat>();
		main = GameObject.FindObjectOfType<Main>();
		screenBounds = main.screenBounds;
		fcc = GameObject.FindObjectOfType<FirstCityConstructed>();
	}

	// Update is called once per frame
	void Update()
	{
		if (fcc.firstCity)
		{
			if (!combat.combat)
			{
				camPos = camera.GetComponent<Transform>().position;
				if (Input.GetKeyUp("d"))
				{
					camera.GetComponent<Transform>().position = new Vector3(camPos.x + screenBounds.y / main.tiles,
						camPos.y,
						camPos.z);
					if (camera.GetComponent<Transform>().position.x > (screenBounds.y * main.tiles + screenBounds.y / main.tiles))
					{
						camPos = camera.GetComponent<Transform>().position;
						camera.GetComponent<Transform>().position = new Vector3(camPos.x - screenBounds.y / main.tiles,
						camPos.y,
						camPos.z);
					}
				}
				if (Input.GetKeyUp("w"))
				{
					camera.GetComponent<Transform>().position = new Vector3(camPos.x,
						camPos.y + screenBounds.y / main.tiles,
						camPos.z);
					if (camera.GetComponent<Transform>().position.y > (screenBounds.y * main.tiles - 4 * screenBounds.y / main.tiles))
					{
						camPos = camera.GetComponent<Transform>().position;
						camera.GetComponent<Transform>().position = new Vector3(camPos.x,
						camPos.y - screenBounds.y / main.tiles,
						camPos.z);
					}
				}
				if (Input.GetKeyUp("a"))
				{
					camera.GetComponent<Transform>().position = new Vector3(camPos.x - screenBounds.y / main.tiles,
						camPos.y,
						camPos.z);
					if (camera.GetComponent<Transform>().position.x < (screenBounds.y))
					{
						camPos = camera.GetComponent<Transform>().position;
						camera.GetComponent<Transform>().position = new Vector3(camPos.x + screenBounds.y / main.tiles,
						camPos.y,
						camPos.z);
					}
				}
				if (Input.GetKeyUp("s"))
				{
					camera.GetComponent<Transform>().position = new Vector3(camPos.x,
						camPos.y - screenBounds.y / main.tiles,
						camPos.z);
					if (camera.GetComponent<Transform>().position.y < (screenBounds.y / 2))
					{
						camPos = camera.GetComponent<Transform>().position;
						camera.GetComponent<Transform>().position = new Vector3(camPos.x,
						camPos.y + screenBounds.y / main.tiles,
						camPos.z);
					}
				}
			}
		}
	}
}
