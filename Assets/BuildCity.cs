using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildCity : MonoBehaviour {

	private int counter = 0;
	private Economy economy;
	private Main main;
	public GameObject city;
	private Vector2 screenBounds;

	// Use this for initialization
	void Start()
	{
		economy = GameObject.FindObjectOfType<Economy>();
		main = GameObject.FindObjectOfType<Main>();
		screenBounds = GameObject.FindObjectOfType<Main>().screenBounds;
	}

	// Update is called once per frame
	void Update () {
		counter += -1;
		if (counter < 0)
		{
			counter = 0;
		}
	}

	void OnMouseDown()
	{
		counter += 60;
		if (counter > 60)
		{
			main.cities.Add(Instantiate(city,
					new Vector2((main.selectedTileX + 0.5f) * main.screenBounds.y / main.tiles, (main.selectedTileY + 0.5f) * main.screenBounds.y / main.tiles), transform.rotation));
			transform.position = new Vector2(-10, -10);
			int temp = 0;
			foreach (GameObject city in main.cities)
			{
				temp += 1;
			}
			main.cities[temp - 1].GetComponent<City>().selectedTileX = main.selectedTileX;
			main.cities[temp - 1].GetComponent<City>().selectedTileY = main.selectedTileY;
			main.armies.Remove(this.gameObject);
			Destroy(this.gameObject);
		}
	}
}
