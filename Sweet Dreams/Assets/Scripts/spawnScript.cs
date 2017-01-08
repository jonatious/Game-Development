using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class spawnScript : MonoBehaviour {

	//char
	public GameObject player;

	//enemy
	public GameObject enemy1;
	public GameObject startPos;
	public GameObject endPos;
	public int ChanceSpawn;

	//coins
	public GameObject coin;
	public static int noOfCoinLocs;
	public GameObject[] coinLocations = new GameObject[noOfCoinLocs];

	//Update Score Card
	public Text survivalTime;

	//enemy
	float enemyLastTime;
	float startTime;
	float lastDiffChangeTime;
	float difficulty;

	float spawnLength;

	void Start()
	{
		difficulty = 1.5f;
		startTime = Time.time;
		lastDiffChangeTime = startTime;
		enemyLastTime = startTime;
		spawnLength = endPos.transform.position.x - startPos.transform.position.x;

		GameConstants.coinsScore = 0;
		GameConstants.timeScore = 0;
	}

	void Update()
	{
		GameConstants.timeScore = Mathf.Round (Time.time - startTime);
		survivalTime.text = "Score = " + (Mathf.Round (Time.time - startTime) + GameConstants.coinsScore);
	}

	void FixedUpdate()
	{
		float currTime = Time.time;
		if (currTime - enemyLastTime > difficulty) {

			if (currTime - lastDiffChangeTime > 4 && difficulty > 0.4f) {
				lastDiffChangeTime = currTime;
				difficulty -= 0.1f;
			}

			Vector3 spawnLoc = transform.position;
			enemyLastTime = currTime;

			if(Random.Range(1,100)  <= ChanceSpawn)
			{
				spawnLoc.x += Random.Range (0, spawnLength);
				Instantiate (enemy1, spawnLoc, Quaternion.Euler (0, 0, 0));
			}

			Collider2D[] platforms = Physics2D.OverlapCircleAll(player.transform.position,50f);

			foreach (Collider2D p in platforms) {
				if (p.tag == "Platform") {
					bool exists = false;
					Collider2D[] coins = Physics2D.OverlapCircleAll (p.transform.position, 5);

					foreach (Collider2D c in coins) {
						if (c.tag == "Coin") {
							exists = true;
							break;
						}
					}

					if (exists || Vector3.Distance (p.transform.position, player.transform.position) < 5)
						continue;
					if(p.gameObject.transform.GetChild(0).name == "RIP")
						if (Random.Range (1, 100) <= 100) {
							Instantiate (coin, p.gameObject.transform.GetChild(0).transform.position, Quaternion.Euler (0, 0, 0));
						}
				}
			}

		}

	}
}