using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

	public Text text;
	private enum States {cell, mirror, sheets_0, lock_0, cell_mirror, sheets_1, lock_1, freedom}
	private States myState;

	// Use this for initialization
	void Start () {		
		myState = States.cell;		
	}
	
	// Update is called once per frame
	void Update () {		
		if (myState == States.cell) 				{state_cell ();}
		else if (myState == States.sheets_0) 		{state_sheets_0 ();} 
		else if (myState == States.lock_0) 			{state_lock_0();}
		else if (myState == States.cell_mirror) 	{state_cell_mirror();}
		else if (myState == States.sheets_1) 		{state_sheets_1 ();} 
		else if (myState == States.lock_1) 			{state_lock_1();}
		else if (myState == States.freedom) 		{state_freedom();}
	}
	
	#region State handlers
	void state_cell_mirror () {
		text.text = "Levetted a tükröt a felról.\n\n" + 
			"Gombok: S a lepedőkhöz, L a zárhoz";
		if (Input.GetKeyDown(KeyCode.S)) 		{myState = States.sheets_1;} 		
		else if (Input.GetKeyDown(KeyCode.L)) 	{myState = States.lock_1;}
	}
	
	void state_cell () {		
		text.text = "Böriben vagy, ki akarsz jutni. " + 
					"Néhány piszkos lepedő van az ágyon, tükör és az ajtó " + 
					"kívülről zárva van.\n\n" + 
					"Gombok: S a lepedőkhöz, M a tükörhöz, L a zárhoz";
		if (Input.GetKeyDown(KeyCode.S)) 		{myState = States.sheets_0;} 
		else if (Input.GetKeyDown(KeyCode.M)) 	{myState = States.cell_mirror;}
		else if (Input.GetKeyDown(KeyCode.L)) 	{myState = States.lock_0;}
	}	
	
	void state_freedom () {
		text.text = "Kijutottál!\n\n" + 
				"Gombok: R újrakezdés";
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell;
		}		
	}
	
	void state_sheets_0 () {
		text.text = "Rondák és Te ebben aludtál. " + 
					"Ideje lenne kicserélni őket.\n\n" + 
					"Gombok: R vissza a cellához";
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell;
		}		
	}
	
	void state_sheets_1 () {
		text.text = "Tükörrel sem szebbek.\n\n" + 
				"Gombok: R vissza a cellához";
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell_mirror;
		}		
	}
	
	void state_lock_0 () {
		text.text = "Számzáras. " + 
			"Nem ismered a kombinációt.\n\n" + 
				"Gombok: R vissza a cellához";
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell;
		}		
	}
	
	void state_lock_1 () {
		text.text = "A tükörrel látod, hogy melyik gombok koszosak. " + 
			"megnyomod őket és kattanást hallasz.\n\n" + 
				"Gombok: O a nyitáshoz, R vissza a cellához";
		if (Input.GetKeyDown(KeyCode.O)) {
			myState = States.freedom;
		} else if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell_mirror;
		}
	}
	
	#endregion 
}
