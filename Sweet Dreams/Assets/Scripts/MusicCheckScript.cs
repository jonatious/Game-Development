using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MusicCheckScript : MonoBehaviour {

	public Sprite clicked;
	public Sprite notClicked;

	public BoxCollider2D musicBtn;

	private float lastTouchTime;

	void Update () 
	{
		if (Input.touchCount == 1 && (Time.time - lastTouchTime) > 0.5) 
		{
			Vector3 wp = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);
			Vector2 touchPos = new Vector2 (wp.x, wp.y);

			if (musicBtn == Physics2D.OverlapPoint (touchPos)) {
				GameConstants.isMusicEnabled = !GameConstants.isMusicEnabled;
				UpdateSprite ();
			}
			lastTouchTime = Time.time;
		}
	}

	void Start()
	{
		lastTouchTime = Time.time;
		UpdateSprite ();
	}

	private void UpdateSprite()
	{
		if (GameConstants.isMusicEnabled)
			GetComponent<SpriteRenderer> ().sprite = clicked;
		else
			GetComponent<SpriteRenderer>().sprite = notClicked;
	}
}
