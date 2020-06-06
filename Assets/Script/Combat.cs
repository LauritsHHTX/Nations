using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour {

	public GameObject line;
	public GameObject combatSpider;
	public GameObject combatLevy;
	public bool combat = false;
	public bool combatty = false;
	private List<GameObject> linesV = new List<GameObject>();
	private List<GameObject> linesH = new List<GameObject>();
	private List<GameObject> combatArmies = new List<GameObject>();
	private List<GameObject> combatMonsters = new List<GameObject>();
	private Unit combatArmy;
	private GameObject theCombatArmy;
	private Unit combatMonster;
	private GameObject theCombatMonsters;
	private Main main;
	private string turn;
	private string loser;


	// Use this for initialization
	void Start () {

		main = GameObject.FindObjectOfType<Main>();
	}

	// Update is called once per frame
	void Update()
	{
		if (combatty)
		{
			foreach (GameObject line in linesV)
			{
				linesV.Remove(line);
				Destroy(line);
			}
			foreach (GameObject line in linesH)
			{
				linesH.Remove(line);
				Destroy(line);
			}
			foreach (IndividualUnits monster in combatMonster.individualUnits)
			{
				if (monster.health <= 0)
				{
					combatMonster.individualUnits.Remove(monster);
				}
			}
			foreach (IndividualUnits soldier in combatArmy.individualUnits)
			{
				if (soldier.health <= 0)
				{
					combatArmy.individualUnits.Remove(soldier); 
				}
			}
			foreach (GameObject army in combatArmies)
			{
				combatArmies.Remove(army);
				Destroy(army);
			}
			foreach (GameObject monster in combatMonsters)
			{
				combatMonsters.Remove(monster);
				Destroy(monster);
			}
			if (loser == "monsters")
			{
				main.monsters.Remove(theCombatMonsters);
				Destroy(theCombatMonsters);
			}
			else if (loser == "army")
			{
				main.armies.Remove(theCombatArmy);
				Destroy(theCombatArmy);
			}
			combatty = false;
		}
	}

	public void StartCombat()
	{
		GameObject.FindObjectOfType<ResetUI>().Reset();
		combat = true;
		for (int i = -2; i <= 2; i++)
		{
			linesH.Add(Instantiate(line,
				new Vector2(transform.position.x, transform.position.y + (i * main.screenBounds.y / main.tiles / 2)), main.transform.rotation));
			linesH[i + 2].GetComponent<Transform>().localScale = new Vector3(10 * main.screenBounds.y / main.tiles / 2, 0.05f, 1);
			linesH[i + 2].GetComponent<Transform>().position = new Vector3(linesH[i + 2].GetComponent<Transform>().position.x, linesH[i + 2].GetComponent<Transform>().position.y, -9);
		}

		for (int i = -5; i <= 5; i++)
		{
			linesV.Add(Instantiate(line,
				new Vector2(transform.position.x + (i * main.screenBounds.y / main.tiles / 2), transform.position.y), main.transform.rotation));
			linesV[i + 5].GetComponent<Transform>().localScale = new Vector3(0.05f, 4 * main.screenBounds.y / main.tiles / 2, 1);
			linesV[i + 5].GetComponent<Transform>().position = new Vector3(linesV[i + 5].GetComponent<Transform>().position.x, linesV[i + 5].GetComponent<Transform>().position.y, -9);
		}
		int temp1 = 0;
		int temp2 = 0;
		foreach (GameObject monster in main.monsters)
		{
			foreach (GameObject levyy in main.armies)
			{
				if (monster.GetComponent<Unit>().selectedTileX == levyy.GetComponent<Unit>().selectedTileX && monster.GetComponent<Unit>().selectedTileY == levyy.GetComponent<Unit>().selectedTileY)
				{
					combatArmy = levyy.GetComponent<Unit>();
					theCombatArmy = levyy;
					combatMonster = monster.GetComponent<Unit>();
					theCombatMonsters = monster;
				}
			}
		}
		foreach (IndividualUnits soldier in combatArmy.individualUnits)
        {
			temp1 += 1;
		}
		foreach (IndividualUnits monster in combatMonster.individualUnits)
		{
			temp2 += 1;
		}
		for (int i = 0; i < temp1; i++)
        {
			if (i > 20)
			{
				combatArmies.Add(Instantiate(combatLevy,
					new Vector2(transform.position.x + ((i - 4.5f) * main.screenBounds.y / main.tiles / 2), transform.position.y + (main.screenBounds.y * main.screenBounds.y / main.tiles / 2)), main.transform.rotation));

			}
			else if (i > 10)
			{
				combatArmies.Add(Instantiate(combatLevy,
					new Vector2(transform.position.x + ((i - 10 - 4.5f) * main.screenBounds.y / main.tiles / 2), transform.position.y + (1.5f * main.screenBounds.y / main.tiles / 2)), main.transform.rotation));
			}
			else
			{
				combatArmies.Add(Instantiate(combatLevy,
					new Vector2(transform.position.x + ((i - 4.5f) * main.screenBounds.y / main.tiles / 2), transform.position.y + (0.5f * main.screenBounds.y / main.tiles / 2)), main.transform.rotation));
			}
			combatArmies[i].GetComponent<Transform>().position = new Vector3(combatArmies[i].GetComponent<Transform>().position.x, combatArmies[i].GetComponent<Transform>().position.y, -9);
		}
		for (int i = 0; i < temp2; i++)
		{
			combatMonsters.Add(Instantiate(combatSpider,
				new Vector2(transform.position.x + ((i - 4.5f) * main.screenBounds.y / main.tiles / 2), transform.position.y - (0.5f * main.screenBounds.y / main.tiles / 2)), main.transform.rotation));
			combatMonsters[i].GetComponent<Transform>().position = new Vector3(combatMonsters[i].GetComponent<Transform>().position.x, combatMonsters[i].GetComponent<Transform>().position.y, -9);
		}
		turn = "monster";


	}

	public void CombatTurn()
	{
		if (turn == "monster")
		{
			int temp = 0;
			foreach (IndividualUnits monster in combatMonster.individualUnits)
			{
				if (monster.health > 0)
				{
					int tempAttack = UnityEngine.Random.Range(1, 20) * 100 + monster.attackBonus + 200;
					if (combatArmy.individualUnits[temp].armor >= tempAttack)
					{
						tempAttack = UnityEngine.Random.Range(1, monster.attackType) * 100 + monster.attackBonus;
						if (combatArmy.individualUnits[temp].health > 0)
						{
							combatArmy.individualUnits[temp].health += -tempAttack;
							combatArmies[temp].GetComponent<Renderer>().material.SetColor("_Color", Color.red);
							if (combatArmy.individualUnits[temp].health > 0)
							{
								combatArmies[temp].GetComponent<Renderer>().material.SetColor("_Color", Color.black);
								temp += 1;
							}
						}
					}
				}
			}
			turn = "army";
		}
		else if (turn == "army")
		{
			int temp = 0;
			foreach (IndividualUnits soldier in combatArmy.individualUnits)
			{
				if (soldier.health > 0)
				{
					int tempAttack = UnityEngine.Random.Range(1, 20) * 100 + soldier.attackBonus + 200;
					if (combatMonster.individualUnits[temp].armor >= tempAttack)
					{
						tempAttack = UnityEngine.Random.Range(1, soldier.attackType) * 100 + soldier.attackBonus;
						if (combatMonster.individualUnits[temp].health > 0)
						{
							combatMonster.individualUnits[temp].health += -tempAttack;
							combatMonsters[temp].GetComponent<Renderer>().material.SetColor("_Color", Color.red);
							if (combatMonster.individualUnits[temp].health > 0)
							{
								combatMonsters[temp].GetComponent<Renderer>().material.SetColor("_Color", Color.black);
								temp += 1;
							}
						}
					}
				}
			}
			turn = "monster";
		}
		int temp1 = 0;
		int temp2 = 0;
		foreach (IndividualUnits soldier in combatArmy.individualUnits)
		{
			if (soldier.health > 0)
			{
				temp1 += 1;
			}
		}
		foreach (IndividualUnits monster in combatMonster.individualUnits)
		{
			if (monster.health > 0)
			{
				temp2 += 1;
			}
		}
		if (temp1 == 0 || temp2 == 0)
		{
			combatty = true;
			combat = false;
			if (temp1 == 0)
			{
				loser = "army";
			}
			else if (temp2 == 0)
            {
				loser = "monsters";
            }
        }
	}
}
