using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

	public static int playerSpeed = 10;

	void FixedUpdate () {
		if(PlayerCol.isAlive)
			transform.Translate (Vector3.right * playerSpeed * Time.fixedDeltaTime);
	}
}
