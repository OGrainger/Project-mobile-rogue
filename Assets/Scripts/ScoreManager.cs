using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(controller))]

public class ScoreManager : MonoBehaviour {

	public Text scoreText;
	public Text highscoreText;
	public Transform playerPosition;
	public GameObject Player;

	public float scoreCount;
	public float highScoreCount;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (Player.GetComponent<controller>().dead) {
			scoreCount = 0;
		}
		scoreCount += 10 * Time.deltaTime;
		scoreText.text = "Score : " + Mathf.Round(scoreCount);
		if (scoreCount > highScoreCount) {
			highScoreCount = scoreCount;
		}
		highscoreText.text = "Highscore : " + Mathf.Round(highScoreCount);
	}
}