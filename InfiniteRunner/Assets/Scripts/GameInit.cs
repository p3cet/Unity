﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInit : MonoBehaviour {

	// Use this for initialization
	void Start () {
		DataManagment.datamanagment.LoadData ();	
		DataManagment.datamanagment.currentScore = 0;
		Debug.Log (Application.persistentDataPath);
	}
	

}
