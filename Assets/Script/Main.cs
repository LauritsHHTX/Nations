using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {
	public int tiles = 10;
	public List<GameObject> cities = new List<GameObject>();
	public List<GameObject> armies = new List<GameObject>();
	public List<GameObject> monsters = new List<GameObject>();
	public int selectedTileX = -5;
	public int selectedTileY = -5;
	public int previouslySelectedTileX = -5;
	public int previouslySelectedTileY = -5;
	public bool selectedTile = false;
	public GameObject line1;
	public GameObject line2;
	public GameObject camera;
	public GameObject selectedTileObject;
	private float something = 0;
	private List<GameObject> lines = new List<GameObject>();
	public Vector2 screenBounds;
	private Combat combat;

	// Use this for initialization
	void Start()
	{
		combat = GameObject.FindObjectOfType<Combat>();
		screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

		camera.transform.position = new Vector3(screenBounds.x, screenBounds.y, -10);

		screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
		for (int iii = 0; iii < (tiles * tiles + 1); iii++)
		{
			for (int ii = 0; ii < (tiles + 1); ii++)
			{
				for (int i = 0; i < (tiles + 1); i++)
				{
					lines.Add(Instantiate(line1,
						new Vector2(transform.position.x + (screenBounds.y / 2 + screenBounds.y * ii), transform.position.y + (i * screenBounds.y / tiles + iii * screenBounds.y / tiles)), transform.rotation));

					lines.Add(Instantiate(line2,
						new Vector2(transform.position.x + (iii * screenBounds.y / tiles + i * screenBounds.y / tiles), transform.position.y + (screenBounds.y / 2 + screenBounds.y * ii)), transform.rotation));
				}
			}
		}
	}


	public void SelectTile()
	{
		if (!combat.combat)
		{
			Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			previouslySelectedTileX = selectedTileX;
			previouslySelectedTileY = selectedTileY;

			for (int i = 1; i < (tiles * tiles + 1); i++)
			{
				if (screenBounds.y / tiles * i > (mouse.x) && (mouse.x) > screenBounds.y / tiles * (i - 1))
				{
					for (int ii = 1; ii < (tiles * tiles + 1); ii++)
					{
						if (screenBounds.y / tiles * ii > (mouse.y) && (mouse.y) > screenBounds.y / tiles * (ii - 1))
						{
							selectedTileX = i - 1;
							selectedTileY = ii - 1;
							selectedTile = true;
							selectedTileObject.transform.position = new Vector3((selectedTileX + 0.5f) * screenBounds.y / tiles, transform.position.y + (selectedTileY + 0.5f) * screenBounds.y / tiles, selectedTileObject.transform.position.z);

						}
					}
				}
			}
		}

	}

	public void MovetoTile()
	{
		bool moved = false;
		
		foreach (GameObject levyy in armies)
		{
			if (levyy.GetComponent<Unit>().selectedTileX == selectedTileX && levyy.GetComponent<Unit>().selectedTileY == selectedTileY)
			{
				levyy.GetComponent<Unit>().MoveArmy();
				moved = true;
			}
		}

		if (moved)
		{
			Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			previouslySelectedTileX = selectedTileX;
			previouslySelectedTileY = selectedTileY;

			for (int i = 1; i < (tiles * tiles + 1); i++)
			{
				if (screenBounds.y / tiles * i > (mouse.x) && (mouse.x) > screenBounds.y / tiles * (i - 1))
				{
					for (int ii = 1; ii < (tiles * tiles + 1); ii++)
					{
						if (screenBounds.y / tiles * ii > (mouse.y) && (mouse.y) > screenBounds.y / tiles * (ii - 1))
						{
							selectedTileX = i - 1;
							selectedTileY = ii - 1;
							selectedTile = true;
							selectedTileObject.transform.position = new Vector3((selectedTileX + 0.5f) * screenBounds.y / tiles, transform.position.y + (selectedTileY + 0.5f) * screenBounds.y / tiles, selectedTileObject.transform.position.z);

						}

					}
				}
			}
		}

	}

}
