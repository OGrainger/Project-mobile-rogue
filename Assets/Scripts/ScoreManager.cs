using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text scoreText;
	public Text highscoreText;
	public Transform playerPosition;
	public GameObject Player;

	public float scoreCount;
	public float highScoreCount;

	private bool isDead;

	// Use this for initialization
	void Start () {
		isDead = Player.GetComponent<controller> ().dead;
	}

	// Update is called once per frame
	void Update () {
		if (isDead) {
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
