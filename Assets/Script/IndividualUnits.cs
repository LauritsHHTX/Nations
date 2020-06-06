using System.Collections;
using UnityEngine;
using System;

public class IndividualUnits : IComparable<IndividualUnits> {

	public string unitType;
	public int x;
	public int y;
	public int health;
	public int maxHealth;
	public int armor;
	public int attackBonus = 100;
	public int attackType = 8;

	public IndividualUnits(string newUnitType, int newHealth, int newArmor)
	{
		unitType = newUnitType;
		health = newHealth;
		armor = newArmor;
		maxHealth = health;
	}
	public int CompareTo(IndividualUnits other)
	{
		if (other == null)
		{
			return 1;
		}
		else
			return 0;
	}
}
