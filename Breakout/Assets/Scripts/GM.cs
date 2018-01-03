using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour {


	public int lives = 3;
	public int bricks =20;
	public float resetDelay = 1f;
	public Text livesText;
	public GameObject gameOver;
	public GameObject youWon;
	public GameObject bricksPrefab;
	public GameObject paddle;
	public GameObject deathParticles;
	public static GM instance = null;

	private GameObject clonePaddle;
	private Transform cloneBall;

	// Use this for initialization
	void Awake () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
		Instantiate (bricksPrefab, transform.position, Quaternion.identity);
		Setup ();
	}

	public void Setup() {
		SetupPaddle ();
		SetupLight ();

	}

	void CheckGameOver() {
		if (bricks < 1) {
			youWon.SetActive (true);
			Time.timeScale = .25f;
			Invoke ("Reset", resetDelay);
		}
		if (lives < 1) {
			gameOver.SetActive (true);
			Time.timeScale = .25f;
			Invoke ("Reset", resetDelay);
		}
	}

	void Reset(){
		Time.timeScale = 1f;
		SceneManager.LoadScene ("scene1");

	}
	
	public void LoseLife(){
		lives--;
		livesText.text = "Lives: " + lives;
		Instantiate (deathParticles, clonePaddle.transform.position, Quaternion.identity);
		Destroy (cloneBall.gameObject);
		Destroy (clonePaddle);
		Invoke ("Setup", resetDelay);
		CheckGameOver();
	}

	void SetupPaddle() {
		clonePaddle = Instantiate (paddle, new Vector3(transform.position.x,-9.5f,transform.position.z), Quaternion.identity) as GameObject;	

	}

	void SetupLight(){
		cloneBall = clonePaddle.transform.GetChild (0);
		LightLookAt.target = cloneBall;	
	}

	public void DestroyBrick() {
		bricks--;
		CheckGameOver ();
	}
}
