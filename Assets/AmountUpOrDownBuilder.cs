using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmountUpOrDownBuilder : MonoBehaviour {

	public int type;
	private int amount;
	public RecruitedAmountBuilder rab;

	// Use this for initialization
	void Start()
	{
		if (type == 1)
			amount = 1;
		else if (type == 0)
			amount = -1;
	}

	void OnMouseDown()
	{
		rab.amount += amount;
		rab.upOrDown();
	}
}
