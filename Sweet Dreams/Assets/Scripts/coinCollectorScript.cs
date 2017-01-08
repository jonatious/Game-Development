using UnityEngine;
using System.Collections;

public class coinCollectorScript : MonoBehaviour {
	
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player")
		{
			GameConstants.coinsScore++;
			Destroy (this.gameObject);
		}
	}

	void Update() {
		transform.position -= transform.up * Time.deltaTime * 0.7f;
	}
}
