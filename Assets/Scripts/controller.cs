using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]



public class controller : MonoBehaviour {
	public float moveSpeed;
	public float jumpForce;

	private Rigidbody2D playerRigidBody;

	public bool grounded;
	public LayerMask whatIsGround;
	private BoxCollider2D playerCollider;
	private Animator animator;

	public LayerMask whatIsPermaDeath;
	public Transform playerStartPoint;
	public Transform PlatformGenerator;
	public Transform Camera;
	public bool dead;
	public int jumpMax;
	private int jumpCounter;

	void Start () {
		playerRigidBody = GetComponent<Rigidbody2D> ();
		playerCollider = GetComponent<BoxCollider2D> ();
		animator = GetComponent<Animator> ();
		jumpCounter = jumpMax;
	}

	void Update () {

		if (playerRigidBody.velocity.y == 0) {
			grounded = Physics2D.IsTouchingLayers (playerCollider, whatIsGround);
		} else {
			grounded = false;
		}


		dead = Physics2D.IsTouchingLayers (playerCollider, whatIsPermaDeath);

		playerRigidBody.velocity = new Vector2(moveSpeed, playerRigidBody.velocity.y);

		if (jumpMax == 0) {
			//
		} else if (Input.GetKeyDown (KeyCode.Space) && jumpCounter == jumpMax && grounded) {
			playerRigidBody.velocity = new Vector2 (playerRigidBody.velocity.x, jumpForce);
			jumpCounter--;
		} else if (Input.GetKeyDown (KeyCode.Space) && jumpCounter == jumpMax) {
			//
		} else if (Input.GetKeyDown (KeyCode.Space) && jumpCounter > 0) {
			playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jumpForce);
			jumpCounter--;
		}

		if (grounded && !Input.GetKeyDown(KeyCode.Space)) {
			jumpCounter = jumpMax;
		}
			
		if (dead) {
			transform.position = new Vector2(playerStartPoint.position.x, playerStartPoint.position.y);
			PlatformGenerator.position = new Vector2(30, 0);
			Camera.position = new Vector2 (0, 1);
		}


	}
	void HandleAnimator()
	{
		animator.SetBool ("grounded", grounded);
		animator.SetFloat ("velocity", playerRigidBody.velocity.x);
	}
}
