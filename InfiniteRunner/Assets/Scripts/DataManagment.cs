using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class DataManagment : MonoBehaviour {

	public static DataManagment datamanagment;
	public int highScore;
	public int currentScore;
	public int coinsCollected;

	void Awake () {
		if (datamanagment == null) {
			DontDestroyOnLoad (gameObject);
			datamanagment = this;
		}
		else if (datamanagment != this) {
			Destroy (gameObject);
		}
	}

	public void SaveData() {
		using (FileStream file = File.Create (Application.persistentDataPath + "/gameInfo.dat")) {
			BinaryFormatter binForm = new BinaryFormatter ();
			gameData data = new gameData ();
			data.highScore = highScore;
			data.coinsCollected = coinsCollected;
			binForm.Serialize (file, data);
		}
	}

	public void LoadData() {
		if (File.Exists (Application.persistentDataPath + "/gameInfo.dat")) {
			using (FileStream file = File.Open (Application.persistentDataPath + "/gameInfo.dat", FileMode.Open)) {
				BinaryFormatter binForm = new BinaryFormatter ();
				gameData data = (gameData)binForm.Deserialize (file);
				highScore = data.highScore;
				coinsCollected = data.coinsCollected;
			}
		}
	}
}

[Serializable]
class gameData {
	public int highScore;
	public int coinsCollected;
}
