using UnityEngine;
using System.Collections;

public class PlatformScript : MonoBehaviour {

	void Update() {
		transform.position -= transform.up * Time.deltaTime * 0.7f;
	}
}
