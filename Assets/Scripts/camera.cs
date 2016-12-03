using UnityEngine;
using System.Collections;

public class camera : MonoBehaviour {

	public Transform playerPosition;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (playerPosition.position.x + 3, playerPosition.position.y + 2.5f, -10);
	}
}
