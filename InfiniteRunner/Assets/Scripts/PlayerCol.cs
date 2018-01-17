using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCol : MonoBehaviour {


	public static bool isAlive=true;

	public AudioClip coinCollect;
	public AudioClip death;

	public GameObject restartUI;

	void OnCollisionEnter(Collision col) {
		if (col.gameObject.tag == "Enemy" && isAlive) {
			GetComponent<AudioSource> ().PlayOneShot (death, 1.0f);
			col.gameObject.GetComponent<Rigidbody> ().isKinematic = false;
			PlayerDies ();
		}
	}

	void OnTriggerEnter(Collider triger) {
		if (triger.gameObject.tag == "Coin") {
			DataManagment.datamanagment.coinsCollected++;
			DataManagment.datamanagment.currentScore++;
			GetComponent<AudioSource> ().PlayOneShot (coinCollect, 1.0f);
			Destroy(triger.gameObject);
		}
	}

	void PlayerDies() {
		//play death audio
		DataManagment.datamanagment.SaveData();
		//activate UI for restarting game
		restartUI.gameObject.SetActive (true);
		GetComponent<Rigidbody> ().isKinematic = true;
		GetComponent<MeshRenderer> ().enabled = false;
		GetComponent<PlayerControls>().enabled = false;
		isAlive=false;
		Time.timeScale = 0.25f;
	}
}
