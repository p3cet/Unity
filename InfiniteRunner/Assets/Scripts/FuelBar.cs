using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelBar : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
		AdjustFuelBar ();	
	}

	void AdjustFuelBar(){
		if(PlayerControls.jetPackFuel > 0.001) 
			gameObject.transform.localScale = new Vector3 (PlayerControls.jetPackFuel, 1, 1);
	}
}
