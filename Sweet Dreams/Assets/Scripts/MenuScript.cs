using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

	public BoxCollider2D playBtn;
	public BoxCollider2D helpBtn;
	public BoxCollider2D OptionsBtn;

	private float startTime;

	void Start()
	{
		startTime = Time.time;
	}

	void Update () {
		if (Input.touchCount == 1 && (Time.time - startTime) > 1)
		{
			Vector3 wp = Camera.main.

				ScreenToWorldPoint(Input.GetTouch(0).position);
			Vector2 touchPos = new Vector2(wp.x, wp.y);

			if (playBtn == Physics2D.OverlapPoint(touchPos))
			{
				GameConstants.coinsScore = 0;
				SceneManager.LoadScene("LoadingScene");
			}

			if (helpBtn == Physics2D.OverlapPoint(touchPos))
			{
				SceneManager.LoadScene("HelpScene");
			}

			if (OptionsBtn == Physics2D.OverlapPoint(touchPos))
			{
				SceneManager.LoadScene("OptionsScene");
			}
		}
	}
}
