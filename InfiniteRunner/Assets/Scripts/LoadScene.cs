using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

	public void LoadToScene() {
		PlayerCol.isAlive = true;
		Time.timeScale = 1.0f;
		SceneManager.LoadScene("Main");
	}
}
