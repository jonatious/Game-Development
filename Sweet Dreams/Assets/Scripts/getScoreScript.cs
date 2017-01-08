using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class getScoreScript : MonoBehaviour {

	public Text score;
	float yourScore;
	float highScore;

	void Start () {
		yourScore = (GameConstants.coinsScore + GameConstants.timeScore);
		highScore = PlayerPrefs.GetInt ("highscore", 0);

		if (highScore < yourScore) {
			PlayerPrefs.SetInt ("highscore", (int)yourScore);
			highScore = yourScore;
		}

		score.text = "Your Score is " + yourScore + "\nHigh Score is " + highScore;
	}
}
