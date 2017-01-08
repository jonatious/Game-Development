using UnityEngine;
using System.Collections;

public class PlatformSpawner : MonoBehaviour {

	public GameObject[] platforms = new GameObject[3];

	public GameObject startPos;
	public GameObject endPos;

	void Start () {

		Vector3 spawnLoc = transform.position;
		float spawnLength = endPos.transform.position.x - startPos.transform.position.x;
		float previousX = 0f;

		for (int i = 1; i < 50; i++) {
			int c;
			if (i < 4)
				c = 0;
			else if (i < 7)
				c = 1;
			else
				c = 2;
			
			spawnLoc = transform.position;
			//spawnLoc.x += Random.Range (0.5f, spawnLength - 1.5f);
			if (c == 0)
				spawnLoc.x += Random.Range (0.5f, spawnLength - 3.5f);
			else if (c == 1)
				spawnLoc.x += Random.Range (0, spawnLength - 1.5f);
			else
				spawnLoc.x += Random.Range (0, spawnLength);
			
			if (Mathf.Abs (spawnLoc.x - previousX) < 0.5)
				spawnLoc.x += 2f;
			previousX = spawnLoc.x;

			spawnLoc.y += i * 4f;
			Instantiate (platforms[c], spawnLoc, Quaternion.Euler (0, 0, 0));
		}
	}
}
