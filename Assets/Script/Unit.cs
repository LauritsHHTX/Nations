using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Unit : MonoBehaviour {
	public int player;
	public int selectedTileX;
	public int selectedTileY;
	public string unitType;
	public List<IndividualUnits> individualUnits = new List<IndividualUnits>();
	private Main main;
	private int moves;
	public int movesLeft;

	// Use this for initialization
	void Start () {
		moves = 3;
		movesLeft = moves;
		main = GameObject.FindObjectOfType<Main>();
		
	}
	

	public void SetUp()
    {
		if (unitType == "Levy")
		{
			individualUnits.Add(new IndividualUnits(unitType, 800, 1300));
		}
		if (unitType == "Spider")
		{
			individualUnits.Add(new IndividualUnits(unitType, 2600, 1400));
		}
		if (unitType == "Builder")
		{
			individualUnits.Add(new IndividualUnits(unitType, 100, 700));
		}
	}

	public void NewTurn()
    {
		movesLeft = moves;
	}

	public void MoveArmy()
    {
		if (player == 1)
		{ 
			Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			for (int i = 1; i < (main.tiles * main.tiles + 1); i++)
			{
				if (main.screenBounds.y / main.tiles * i > (mouse.x) && (mouse.x) > main.screenBounds.y / main.tiles * (i - 1))
				{
					for (int ii = 1; ii < (main.tiles * main.tiles + 1); ii++)
					{
						if (main.screenBounds.y / main.tiles * ii > (mouse.y) && (mouse.y) > main.screenBounds.y / main.tiles * (ii - 1))
						{
							int temp1 = i - 1 - selectedTileX;
							int temp2 = ii - 1 - selectedTileY;

							if (temp1 < 0)
							{
								temp1 = temp1 * -1;
							}
							if (temp2 < 0)
							{
								temp2 = temp2 * -1;
							}
							if (movesLeft >= (temp1 + temp2))
							{
								movesLeft += -(temp1 + temp2);
								Debug.Log("Right");
								selectedTileX = i - 1;
								selectedTileY = ii - 1;
								transform.position = new Vector3((selectedTileX + 0.5f) * main.screenBounds.y / main.tiles, (selectedTileY + 0.5f) * main.screenBounds.y / main.tiles, transform.position.z);
								foreach (GameObject monster in main.monsters)
                                {
									if (monster.GetComponent<Unit>().selectedTileX == selectedTileX && 
										monster.GetComponent<Unit>().selectedTileY == selectedTileY)
									{
										GameObject.FindObjectOfType<Combat>().StartCombat();
									}
								}
								
							}
							foreach (IndividualUnits soldier in individualUnits)
							{
								Debug.Log(soldier);
								Debug.Log(soldier.health);
							}
						
						}
					}
				}
			}
		}
	}

	//public void MonsterMove()
    //{
		//if (player == 0)
        //{

        //}
    //}
}
