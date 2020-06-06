using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class City : MonoBehaviour
{
	private Main main;
	private int counter = 0;
	public float cityGoldIncome;
	public float cityMetalIncome;
	public int selectedTileX = -5;
	public int selectedTileY = -5;
	public GameObject levy;
	public GameObject builder;
	private RecruitedAmountLevy raLevy;
	private RecruitedAmountBuilder raBuilder;

	// Use this for initialization
	void Start()
	{
		main = GameObject.FindObjectOfType<Main>();
		raLevy = GameObject.FindObjectOfType<RecruitedAmountLevy>();
		raBuilder = GameObject.FindObjectOfType<RecruitedAmountBuilder>();
	}

	// Update is called once per frame
	void Update()
	{
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
			print(counter);
			if (counter > 120)
			{
				counter = 0;
				Debug.Log("hello");
			}
		}
	}

	public void calculateIncome()
	{
		cityGoldIncome = 10;

	}

	public void enlist()
	{
		for (int i = 0; i < raLevy.amount; i++)
		{
			if (GameObject.FindObjectOfType<Economy>().gold >= 10)
			{
				main.armies.Add(Instantiate(levy,
							new Vector2(transform.position.x, transform.position.y), transform.rotation));
				int temp = 0;
				foreach (GameObject levyy in main.armies)
				{
					temp += 1;
				}
				main.armies[temp - 1].GetComponent<Unit>().selectedTileX = selectedTileX;
				main.armies[temp - 1].GetComponent<Unit>().selectedTileY = selectedTileY;
				main.armies[temp - 1].GetComponent<Transform>().position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
				main.armies[temp - 1].GetComponent<Unit>().SetUp();
				GameObject.FindObjectOfType<Economy>().gold += -10;
			}
		}
		for (int i = 0; i < raBuilder.amount; i++)
		{
			if (GameObject.FindObjectOfType<Economy>().gold >= 100)
			{
				main.armies.Add(Instantiate(builder,
							new Vector2(transform.position.x, transform.position.y), transform.rotation));
				int temp = 0;
				foreach (GameObject levyy in main.armies)
				{
					temp += 1;
				}
				main.armies[temp - 1].GetComponent<Unit>().selectedTileX = selectedTileX;
				main.armies[temp - 1].GetComponent<Unit>().selectedTileY = selectedTileY;
				main.armies[temp - 1].GetComponent<Transform>().position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
				main.armies[temp - 1].GetComponent<Unit>().SetUp();
				GameObject.FindObjectOfType<Economy>().gold += -100;
			}

		}
	}
}