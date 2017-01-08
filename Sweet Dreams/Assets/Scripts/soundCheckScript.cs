using UnityEngine;
using System.Collections;

public class soundCheckScript : MonoBehaviour {

	public Sprite clicked;
	public Sprite notClicked;

	public BoxCollider2D soundBtn;

	private float lastTouchTime;

	void Update () 
	{
		if (Input.touchCount == 1 && (Time.time - lastTouchTime) > 0.5) 
		{
			Vector3 wp = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);
			Vector2 touchPos = new Vector2 (wp.x, wp.y);

			if (soundBtn == Physics2D.OverlapPoint (touchPos)) {
				GameConstants.isSoundEnabled = !GameConstants.isSoundEnabled;
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
		if (GameConstants.isSoundEnabled)
			GetComponent<SpriteRenderer> ().sprite = clicked;
		else
			GetComponent<SpriteRenderer>().sprite = notClicked;
	}
}
