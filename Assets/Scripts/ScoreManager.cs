using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(controller))]

public class ScoreManager : MonoBehaviour {
	
	private Transform playerPosition;

	private float scoreCount;
	private float highScoreCount;

	public Text scoreText;
	public Text highscoreText;
	public GameObject Player;

	// Use this for initialization
	void Start () {
		highScoreCount = PlayerPrefs.GetFloat ("highScore");
		playerPosition = Player.GetComponent<Transform> ();
		
	}

	// Update is called once per frame
	void Update () {
		
		scoreCount = playerPosition.position.x;

		if (Player.GetComponent<controller>().dead) {
			if (scoreCount > highScoreCount) {
				PlayerPrefs.SetFloat("highScore", scoreCount);
			}
			scoreCount = 0;
		}

		scoreText.text = "Score : " + Mathf.Round(scoreCount);
		if (scoreCount > highScoreCount) {
			highScoreCount = scoreCount;
		}
		highscoreText.text = "Highscore : " + Mathf.Round(highScoreCount);
	}
}