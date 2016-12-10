using UnityEngine;
using System.Collections;

public class pauseManager : MonoBehaviour {

	public bool pause;

	public GameObject dim;
	public GameObject button1;
	public GameObject button2;

	// Use this for initialization
	void Start () {
		pause = false;
		dim.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			PauseSwitch();
		}
	}

	public void PauseSwitch () {

		pause = !pause;

		if (pause) {
			Time.timeScale = 0;
			button1.SetActive (false);
			button2.SetActive (false);
			dim.SetActive (true);
		} else {
			Time.timeScale = 1;
			button1.SetActive (true);
			button2.SetActive (true);
			dim.SetActive (false);
		}
	}
}
