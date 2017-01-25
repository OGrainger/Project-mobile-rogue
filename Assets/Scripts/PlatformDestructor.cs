using UnityEngine;
using System.Collections;

public class PlatformDestructor : MonoBehaviour {

	private float widthOfPlatform;

	public GameObject platformDestructPoint;
	public GameObject Player;

	// Use this for initialization
	void Start () {
		platformDestructPoint = GameObject.Find ("PlatformDestructPoint");
		Player = GameObject.Find ("Player");
		widthOfPlatform = GetComponent<ObjectInfo> ().widthDifference;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x + widthOfPlatform < platformDestructPoint.transform.position.x || Player.GetComponent<Transform>().position.x < 5) {
			Destroy (gameObject);
		}
	}
}
