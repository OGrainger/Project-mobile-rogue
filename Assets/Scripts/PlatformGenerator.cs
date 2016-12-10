using UnityEngine;
using System.Collections;

public class PlatformGenerator : MonoBehaviour {
	
	public float platformWidthDifference;

	private float heightDifference;
	private float platformHeightDifference;

	private int platformSelector;
	private GameObject platform;
	private int previousPlatformSelector;

	public GameObject[] platforms;

	public Transform generationPoint;

	public float distanceBetween;


	public float heightDifferenceMax;

	// Use this for initialization
	void Start () {
		previousPlatformSelector = 0;
	}

	// Update is called once per frame
	void Update () {
		if (transform.position.x < generationPoint.position.x) {

			heightDifference = HeightCalc ();

			platformSelector = Random.Range (0, platforms.Length);
			
			platform = platforms [platformSelector];
			platformWidthDifference = platform.GetComponent<ObjectInfo>().widthDifference;
			platformHeightDifference = platform.GetComponent<ObjectInfo>().heightDifference;

			Instantiate (platform, transform.position, transform.rotation);

			transform.position = new Vector3 (transform.position.x + platformWidthDifference + distanceBetween, transform.position.y + platformHeightDifference + heightDifference, transform.position.z);

			previousPlatformSelector = platformSelector;
		}
	}

	public float HeightCalc () {
		heightDifference = Random.Range (-(heightDifferenceMax), heightDifferenceMax);

		if (heightDifference < heightDifferenceMax/2 && heightDifference > -heightDifferenceMax/2) {
			heightDifference = 0;
		} else if (heightDifference >= heightDifferenceMax/2) {
			heightDifference = heightDifferenceMax;
		} else if (heightDifference <= -heightDifferenceMax/2) {
			heightDifference = -heightDifferenceMax;
		}
		return heightDifference;
	}
}
