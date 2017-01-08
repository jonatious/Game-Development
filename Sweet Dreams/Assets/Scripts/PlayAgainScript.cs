using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayAgainScript : MonoBehaviour {

	public BoxCollider2D playAgainBtn;

	void Update () 
	{
		if (Input.touchCount == 1) 
		{
			Vector3 wp = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);
			Vector2 touchPos = new Vector2 (wp.x, wp.y);

			if (playAgainBtn == Physics2D.OverlapPoint (touchPos)) {
				SceneManager.LoadScene ("MenuScene");
			}
		}
	}
}