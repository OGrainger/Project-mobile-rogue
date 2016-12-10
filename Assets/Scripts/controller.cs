using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Animator))]

public class controller : MonoBehaviour {
	
	private BoxCollider2D playerCollider;
	private Animator animator;
	private Rigidbody2D playerRigidBody;

	private bool trigger_jumpsReset;
	private bool trigger_playerIsOffGround;

	private int jumpCounter;
	private bool jumpKey;

	private bool switch_secondary;

	//Les 2 float bougeront en private en haut après être sûr que ça ne bug pas
	public float moveSpeed;
	public float jumpForce;

	public bool grounded;
	public bool dead;
	public LayerMask whatIsGround;
	public LayerMask whatIsPermaDeath;

	public Transform playerStartPoint;
	public Transform PlatformGenerator;

	public int jumpMax;


	void Start () {
		playerRigidBody = GetComponent<Rigidbody2D> ();
		playerCollider = GetComponent<BoxCollider2D> ();
		animator = GetComponent<Animator> ();

		jumpCounter = jumpMax;

		trigger_jumpsReset = false;
		trigger_playerIsOffGround = true;

		switch_secondary = false;
	}

	void Update () {

		//Variables pour les animations
		animator.SetBool ("grounded", grounded);
		animator.SetFloat ("velocityX", playerRigidBody.velocity.x);
		animator.SetFloat ("velocityY", playerRigidBody.velocity.y);

		//Si le joueur est mort
		dead = Physics2D.IsTouchingLayers (playerCollider, whatIsPermaDeath);

		grounded = Physics2D.IsTouchingLayers (playerCollider, whatIsGround);

		//PAS SUR ORDI
		jumpKey = Input.GetKeyDown(KeyCode.Space);

		if (jumpKey) {
			Jump ();
		}

		if (grounded && !trigger_jumpsReset) {
			trigger_jumpsReset = true;
			trigger_playerIsOffGround = false;
			jumpCounter = jumpMax;

		} else if (!grounded && !trigger_playerIsOffGround) {
			trigger_jumpsReset = false;
			trigger_playerIsOffGround = true;
			jumpCounter--;
		}

		if (dead) {
			transform.position = new Vector2(playerStartPoint.position.x, playerStartPoint.position.y);
			PlatformGenerator.position = new Vector2(100, 0);
		}
	}

	void FixedUpdate () {

		playerRigidBody.velocity = new Vector2 (moveSpeed, playerRigidBody.velocity.y);

	}

	public void Jump() {
		if (jumpMax == 0) {
			return;
		} else if (jumpCounter == jumpMax) {
			playerRigidBody.velocity = new Vector2 (moveSpeed, jumpForce);
			return;
		} else if (jumpCounter > 0) {
			playerRigidBody.velocity = new Vector2 (moveSpeed, jumpForce);
			jumpCounter--;
			return;
		} else {
			return;
		}
	}

	public void Secondary () {
		if (!switch_secondary) {
			Time.timeScale = 0.5f;
			switch_secondary = true;
		} else {
			Time.timeScale = 1;
			switch_secondary = false;
		}

	}
}
