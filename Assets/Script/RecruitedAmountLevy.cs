using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class RecruitedAmountLevy : MonoBehaviour {
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
