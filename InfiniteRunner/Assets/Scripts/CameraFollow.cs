using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	private GameObject player;
	public float cameraSpeed = 5.0f;

	private float prevoiusPlayerY;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		prevoiusPlayerY = player.transform.position.y;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//X position follow
		Vector3 camPos = transform.position;
		camPos.x = player.transform.position.x+10;
		transform.position = Vector3.Lerp (transform.position, camPos, cameraSpeed * Time.fixedDeltaTime);

		//Y position follow
		camPos.y=player.transform.position.y;
		transform.position = Vector3.Lerp (transform.position, camPos, 2 * cameraSpeed * Time.fixedDeltaTime);

		//move camera back to see more game space; depends on y position of player
		camPos.z += 3*(prevoiusPlayerY - player.transform.position.y);
		transform.position = Vector3.Lerp (transform.position, camPos, 2 * cameraSpeed * Time.fixedDeltaTime);
		prevoiusPlayerY = player.transform.position.y;
	}
}
