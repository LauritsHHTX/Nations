using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class NewTurn : MonoBehaviour {
	public GameObject spider;
	private Economy economy;
	private Main main;
	private Combat combat;

	// Use this for initialization
	void Start()
	{
		combat = GameObject.FindObjectOfType<Combat>();
		economy = GameObject.FindObjectOfType<Economy>();
		main = GameObject.FindObjectOfType<Main>();
	}
	
	// Update is called once per frame
	void Update () {
		consolidate();
	}

	void OnMouseDown()
	{
		if (combat.combat != true)
		{
			economy.income();
			foreach (GameObject city in main.cities)
			{
				city.GetComponent<City>().enlist();
			}
			foreach (GameObject levy1 in main.armies)
			{
				levy1.GetComponent<Unit>().NewTurn();
			}
			int temp0 = 0;
			int temp1 = 0;
			int temp2 = 0;
			for (int i = 0; i < main.tiles; i++)
			{
				for (int ii = 0; ii < main.tiles; ii++)
				{
					temp0 = UnityEngine.Random.Range(1, 101);
					if (temp0 < 21)
					{
						bool spawnMonster = true;
						temp1 = UnityEngine.Random.Range(i * main.tiles, (i + 1) * main.tiles - 1);
						temp2 = UnityEngine.Random.Range(ii * main.tiles, (ii + 1) * main.tiles - 1);
						foreach (GameObject city in main.cities)
						{
							if (city.GetComponent<City>().selectedTileX == temp1 && city.GetComponent<City>().selectedTileY == temp2)
							{
								spawnMonster = false;
							}
						}
						foreach (GameObject levy1 in main.armies)
						{
							if (levy1.GetComponent<Unit>().selectedTileX == temp1 && levy1.GetComponent<Unit>().selectedTileY == temp2)
							{
								spawnMonster = false;
							}
						}
						if (spawnMonster)
						{
							main.monsters.Add(Instantiate(spider,
								new Vector2((temp1 + 0.5f) * main.screenBounds.y / main.tiles, (temp2 + 0.5f) * main.screenBounds.y / main.tiles), transform.rotation));
							int temp = 0;
							foreach (GameObject monster in main.monsters)
							{
								temp += 1;
							}

							main.monsters[temp - 1].GetComponent<Unit>().selectedTileX = temp1;
							main.monsters[temp - 1].GetComponent<Unit>().selectedTileY = temp2;
							main.monsters[temp - 1].GetComponent<Unit>().SetUp();
						}
					}
				}
			}
		}
		else
			combat.CombatTurn();
	}

	void consolidate()
    {
		foreach (GameObject levy1 in main.armies)
		{

			foreach (GameObject levy2 in main.armies)
			{
				if (levy1 != levy2)
				{
					if (levy1.GetComponent<Unit>().selectedTileX == levy2.GetComponent<Unit>().selectedTileX && levy1.GetComponent<Unit>().selectedTileY == levy2.GetComponent<Unit>().selectedTileY && levy1.GetComponent<Unit>().movesLeft == levy2.GetComponent<Unit>().movesLeft)
					{
						foreach (IndividualUnits soldier in levy2.GetComponent<Unit>().individualUnits)
							levy1.GetComponent<Unit>().individualUnits.Add(soldier);
						main.armies.Remove(levy2);
						Destroy(levy2);
					}
				}
			}
		}
	}

}
