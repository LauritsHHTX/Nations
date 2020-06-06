using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstCityConstructed : MonoBehaviour
{
	private Economy economy;
	private Main main;
	public GameObject city;
	public bool firstCity;
	private Vector2 screenBounds;

	// Use this for initialization
	void Start()
	{
		economy = GameObject.FindObjectOfType<Economy>();
		main = GameObject.FindObjectOfType<Main>();
		screenBounds = GameObject.FindObjectOfType<Main>().screenBounds;
		firstCity = false; 
	}

	public void SetUp()
    {

		transform.position = new Vector3(screenBounds.x / 2 * 1.5f, screenBounds.y / 2, transform.position.z);
	}
	
	void OnMouseDown()
	{
		if (main.selectedTile)
        {

			economy.gold = economy.gold - 100;
			main.cities.Add(Instantiate(city,
					new Vector2((main.selectedTileX + 0.5f) * main.screenBounds.y / main.tiles, (main.selectedTileY + 0.5f) * main.screenBounds.y / main.tiles), transform.rotation));
			transform.position = new Vector2(-10, -10);
			firstCity = true;
			int temp = 0;
			foreach (GameObject city in main.cities) 
			{
				temp += 1;
			}
			main.cities[temp - 1].GetComponent<City>().selectedTileX = main.selectedTileX;
			main.cities[temp - 1].GetComponent<City>().selectedTileY = main.selectedTileY;


		}

	}
	
}
