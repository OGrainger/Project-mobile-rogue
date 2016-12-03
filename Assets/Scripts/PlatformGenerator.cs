using UnityEngine;
using System.Collections;

public class PlatformGenerator : MonoBehaviour {

	public Transform generationPoint;
	private float distanceBetween;

	private float platformWidth;


	public float distanceBetweenMin;
	public float distanceBetweenMax;

	public GameObject[] platforms;

	private int platformSelector;

	private GameObject platform;

	private float heightMin = 0;
	private float heightMax = 20;
	public float heightDifferenceMax;
	private float heightDifference;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < generationPoint.position.x) {
			distanceBetween = Random.Range (distanceBetweenMin, distanceBetweenMax);

			heightDifference = Random.Range (-(heightDifferenceMax), heightDifferenceMax);
			if (heightDifference < 1 && heightDifference > -1) {
				heightDifference = 0;
			}

			if (distanceBetween < 3) {
				distanceBetween = 0;
				heightDifference = 0;
			}

			platformSelector = Random.Range (0, platforms.Length);
			platform = platforms [platformSelector];
			platformWidth = platform.GetComponent<BoxCollider2D>().size.x;

			Instantiate (platform, transform.position, transform.rotation);

			transform.position = new Vector3 (transform.position.x + platformWidth + distanceBetween, transform.position.y + heightDifference, transform.position.z);


		}
	}
}
