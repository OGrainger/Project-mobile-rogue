using UnityEngine;
using System.Collections;

public class controller : MonoBehaviour {
	public float moveSpeed;
	public float jumpForce;

	private Rigidbody2D playerRigidBody;

	public bool grounded;
	public LayerMask whatIsGround;
	private BoxCollider2D playerCollider;

	public LayerMask whatIsPermaDeath;
	public Transform playerStartPoint;
	public Transform PlatformGenerator;
	public Transform Camera;
	public bool dead;

	void Start () {
		playerRigidBody = GetComponent<Rigidbody2D> ();
		playerCollider = GetComponent<BoxCollider2D> ();
	}

	void Update () {

		grounded = Physics2D.IsTouchingLayers (playerCollider, whatIsGround);

		dead = Physics2D.IsTouchingLayers (playerCollider, whatIsPermaDeath);

		playerRigidBody.velocity = new Vector2(moveSpeed, playerRigidBody.velocity.y);

		if (Input.GetKeyDown(KeyCode.Space) && grounded)
		{
			playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jumpForce);
		}

		if (dead) {
			transform.position = new Vector2(playerStartPoint.position.x, playerStartPoint.position.y);
			PlatformGenerator.position = new Vector2(30, 0);
			Camera.position = new Vector2 (0, 1);
		}
	}
}
