using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {

	public GameObject player;
	public GameObject[] coins;
	public GameObject[] trees;

	public GameObject enemy;
	private float coinSpawnTimer = 2.0f;
	private float enemySpawnTimer = 5.0f;
	private float treeSpawnTimer = 1f;
	// Update is called once per frame
	void Update () {
		coinSpawnTimer -= Time.deltaTime;
		enemySpawnTimer -= Time.deltaTime;
		treeSpawnTimer -= Time.deltaTime;

		if (coinSpawnTimer < 0.01 && PlayerCol.isAlive) {
			SpawnCoins ();
		}

		if (enemySpawnTimer < 0.01 && PlayerCol.isAlive) {
			SpawnEnemy ();
		}

		if (treeSpawnTimer < 0.01 && PlayerCol.isAlive) {
			SpawnTree ();
		}

	}

	void SpawnCoins() {
		Instantiate (coins [Random.Range (0, coins.Length)], new Vector3 (player.transform.position.x + 30, Random.Range(2,8),0),Quaternion.identity);
		coinSpawnTimer = Random.Range (1.0f, 3.0f);
	}

	void SpawnEnemy() {
		enemy.transform.localScale = new Vector3 (Random.Range (1, 5), Random.Range (1, 5), Random.Range (1, 5));
		Instantiate(enemy,new Vector3(player.transform.position.x+30,Random.Range(1,9),0),Quaternion.Euler(Random.Range(0,45),0,0));
		enemySpawnTimer = Random.Range(2,4);
	}

	void SpawnTree() {
		Instantiate(trees[Random.Range(0,trees.Length)],new Vector3(player.transform.position.x+70,0,Random.Range(3,22)),Quaternion.Euler(0,Random.Range(0,360),0));
		treeSpawnTimer = Random.Range (0.1f, 0.3f);
	}
}
