using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {


	public static float jetPackFuel = 1.5f;
	public float jetPackForce = 10.0f;

	public AudioClip jetPack;
	private AudioSource audioSource;

	void Awake() {
		audioSource = GetComponent<AudioSource> ();
		//audioSource.clip = jetPack;	
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetButton ("Jump") && jetPackFuel >= 0.001f) {
			BoostUp ();
			audioSource.PlayOneShot(jetPack,0.1f);
		}

	}

	void BoostUp() {
		//change jetpackfuel value
		jetPackFuel = Mathf.MoveTowards (jetPackFuel, 0, Time.fixedDeltaTime);
		GetComponent<Rigidbody> ().AddForce (new Vector3 (0, jetPackForce));
	}

	void OnCollisionEnter (Collision col) {
		//reset jetpack fuel
		if (col.gameObject.tag == "Ground") {
			jetPackFuel = 1.5f;
		}
	}
}
