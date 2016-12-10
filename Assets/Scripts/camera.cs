using UnityEngine;
using System.Collections;

public class camera : MonoBehaviour {

	public Transform playerPosition;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = new Vector3 (playerPosition.position.x + 18, playerPosition.position.y + 7, -25);
	}
}
