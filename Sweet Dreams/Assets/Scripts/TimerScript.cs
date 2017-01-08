using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour {

	float startTime;
	AudioSource source;

	public AudioClip coinCollectSound;

	void Start()
	{
		source = GetComponent<AudioSource>();
		startTime = Time.time;
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
			GameConstants.timeScore = Mathf.Round (Time.time - startTime);
		}
		if (col.gameObject.tag == "Coin")
		{
			if(GameConstants.isSoundEnabled)
				source.PlayOneShot (coinCollectSound, 1f);
		}
    }
}
