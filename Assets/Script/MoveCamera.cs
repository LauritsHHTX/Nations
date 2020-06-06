using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {

	public int mode; 
	public GameObject camera;
	private Main main;
	private Vector2 screenBounds;
	private Vector3 camPos;
	private Combat combat;

	// Use this for initialization
	void Start () {
		main = GameObject.FindObjectOfType<Main>();
		screenBounds = GameObject.FindObjectOfType<Main>().screenBounds;
		combat = GameObject.FindObjectOfType<Combat>();

	}

	// Update is called once per frame

	void OnMouseDown()
	{
		if (!combat.combat)
		{
			camPos = camera.GetComponent<Transform>().position;
			if (mode == 2)
			{
				camera.GetComponent<Transform>().position = new Vector3(camPos.x + main.screenBounds.y / main.tiles,
						camPos.y,
						camPos.z);
				if (camera.GetComponent<Transform>().position.x > (main.screenBounds.y * main.tiles + main.screenBounds.y / main.tiles))
				{
					camPos = camera.GetComponent<Transform>().position;
					camera.GetComponent<Transform>().position = new Vector3(camPos.x - main.screenBounds.y / main.tiles,
					camPos.y,
					camPos.z);
				}
			}
			if (mode == 1)
			{
				camera.GetComponent<Transform>().position = new Vector3(camPos.x,
					camPos.y + screenBounds.y / main.tiles,
					camPos.z);
				if (camera.GetComponent<Transform>().position.y > (screenBounds.y * main.tiles + screenBounds.y / main.tiles))
				{
					camPos = camera.GetComponent<Transform>().position;
					camera.GetComponent<Transform>().position = new Vector3(camPos.x,
					camPos.y - screenBounds.y / main.tiles,
					camPos.z);
				}
			}
			if (mode == 4)
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
			if (mode == 3)
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
