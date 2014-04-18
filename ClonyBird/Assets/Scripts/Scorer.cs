using UnityEngine;
using System.Collections;

public class Scorer : MonoBehaviour {

	private int score;
	private int highScore;

	private const string HIGHSCORE_PREF = "highscore";

	public int Score {
		get { return score; }
	}

	public int HighScore {
		get { return highScore; }
	}

	public void AddPoint() {
		++score;
		if (score > highScore) {
			highScore = score;
		}
	}

	void Start() {
		highScore = PlayerPrefs.GetInt (HIGHSCORE_PREF, 0);
	}

	void OnDestroy() {
		PlayerPrefs.SetInt (HIGHSCORE_PREF, highScore);
	}

	void Update () {
		guiText.text = "Score: " + score + "\nHigh Score: " + highScore;
	}
}
