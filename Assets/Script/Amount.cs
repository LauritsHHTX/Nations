using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Amount : MonoBehaviour
{
	public Text text;
	public int amount;
	private Main main;
	private bool something;

	// Use this for initialization
	void Start()
	{
		main = GameObject.FindObjectOfType<Main>();

	}

	public void changedAmount()
	{
		something = true;
		amount = 0;
		foreach (GameObject levyy in main.armies)
		{
			if (main.selectedTileX == levyy.GetComponent<Unit>().selectedTileX && main.selectedTileY == levyy.GetComponent<Unit>().selectedTileY)
			{
				foreach (IndividualUnits soldier in levyy.GetComponent<Unit>().individualUnits)
                {
					amount += 1;
				}
				text.text = "" + amount;
				something = false;
			}
		
		}
		if (something)
			text.text = "" + amount;
	}
}
