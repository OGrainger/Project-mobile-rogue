using UnityEngine;
using System.Collections;

public class PlatformDestructor : MonoBehaviour {

	public GameObject platformDestructPoint;
	public GameObject Player;

	// Use this for initialization
	void Start () {
		platformDestructPoint = GameObject.Find ("PlatformDestructPoint");
		Player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < platformDestructPoint.transform.position.x || Player.GetComponent<controller>().dead) {
			Destroy (gameObject);
		}
	}
}
