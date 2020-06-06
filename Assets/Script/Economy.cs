using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Economy : MonoBehaviour {

	private Main main;
	public Text GoldNMetal;
	public float gold;
	public float goldIncome;
	public float metal;
	public float metalIncome;

	// Use this for initialization
	void Start () {
		layout();
		main = GameObject.FindObjectOfType<Main>();
	}
	
	// Update is called once per frame
	void Update () {
		layout();
	}

	void layout()
    {
		GoldNMetal.text = "Gold: " + gold + "   +" + goldIncome;// + "     Metal: " + metal + "   +" + metalIncome;
    }

	public void income()
	{
		goldIncome = 0;
		foreach (GameObject city in main.cities)
		{
			city.GetComponent<City>().calculateIncome();
			goldIncome += city.GetComponent<City>().cityGoldIncome;
		}
		gold += goldIncome;
	}
}