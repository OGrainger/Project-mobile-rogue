using UnityEngine;
using System.Collections;

public class oneWayManager : MonoBehaviour {

	public GameObject oneWayGround;
	public GameObject player;
	public bool isGoingUp;

	// Use this for initialization
	void Start () {
		oneWayGround = transform.GetChild (0).gameObject;
		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		isGoingUp = player.GetComponent<Rigidbody2D>().velocity.y >= 0;
		if (isGoingUp) {
			oneWayGround.SetActive (false);
		} else {
			oneWayGround.SetActive (true);
		}
	}
}