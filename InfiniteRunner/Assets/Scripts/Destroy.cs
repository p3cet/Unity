using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

	private float timeToDestroy = 10.0f;

	void Update () {
		timeToDestroy -= Time.deltaTime;
		if (timeToDestroy <= 0.01f)
			Destroy (gameObject);
	}
}
