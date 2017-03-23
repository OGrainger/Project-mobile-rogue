using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class tutorialManager : MonoBehaviour {

	public GameObject jumpButton;
	public GameObject secondaryButton;
	public GameObject tutoJump;
	public GameObject tutoSecondary;
	public GameObject tutoPause;

	private float timeLeft;
	private bool tutorialIsOver;

	// Use this for initialization
	void Start () {
		tutorialIsOver = false;
		timeLeft = 2.5F;

		Destroy (tutoJump, 2.5F);
		Destroy (tutoPause, 2.5F);
		Destroy (tutoSecondary, 2.5F);

	}
	
	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;
		if (timeLeft <= 0 && !tutorialIsOver) {
			tutorialIsOver = true;
			jumpButton.GetComponent<Image> ().color = new Color(255, 0, 0, 0);
			secondaryButton.GetComponent<Image> ().color = new Color(0, 255, 0, 0);	}
	}
}
