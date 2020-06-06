using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmountUpOrDown : MonoBehaviour
{
	public int type;
	public RecruitedAmountLevy ra;
	private int amount;

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
		ra.amount += amount;
		ra.upOrDown();
	}
}
