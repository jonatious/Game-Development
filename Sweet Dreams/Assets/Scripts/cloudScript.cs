using UnityEngine;
using System.Collections;

public class cloudScript : MonoBehaviour {

	public float speed = 0.5f;
	private MeshRenderer sprite;

	void Start () {
		sprite = GetComponent<MeshRenderer> ();

	}

	void Update () {
		Vector2 offset = new Vector2(Time.time * speed, 0);
		sprite.material.mainTextureOffset = offset;
	}
}
