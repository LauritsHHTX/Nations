using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecruitedAmountBuilder : MonoBehaviour {

	public Text text;
	public int amount;

	void changedAmount()
	{
		text.text = "" + amount;
	}

	public void upOrDown()
	{
		changedAmount();
	}

}
