using UnityEngine;
using System.Collections;

public class checkMusicEnabledScript : MonoBehaviour {

	void Start () {
		AudioSource mySource = GetComponent<AudioSource> ();
		if (!GameConstants.isMusicEnabled)
			mySource.volume = 0;
	}
}
