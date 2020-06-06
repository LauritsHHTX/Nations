using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour {

	public int whoseTurn;
	private int amountOfEmpires = 2;

	// Use this for initialization
	void Start () {
		whoseTurn = 1;
	}
	
	void OnMouseDown()
	{
		if (whoseTurn < amountOfEmpires)
		{
			whoseTurn += 1;
		}
		else if (whoseTurn == amountOfEmpires)
        {
			whoseTurn = 1;
        }
		print(whoseTurn);
	}
}
