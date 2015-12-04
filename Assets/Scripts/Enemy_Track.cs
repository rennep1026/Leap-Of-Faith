using UnityEngine;
using System.Collections;

public class Enemy_Track : MonoBehaviour {
	public Transform groundCheck;

	private float jumpForce = 250f;
	private bool grounded = false;
	private SimplePlatformController controller;
	private float maxSpeed = 3f;
	private Rigidbody2D rb2d;


	// Use this for initialization
	void Start () {
		GameObject controllerObject = GameObject.FindWithTag("Player");
		controller = controllerObject.GetComponent<SimplePlatformController>();
		rb2d = GetComponent<Rigidbody2D>();
	}

	void OnCollisionEnter2D (Collision2D other)
	{ 
		if (other.gameObject.CompareTag("ground"))
		{
			grounded = true;
		}
	}

	void FixedUpdate() {
		if (Vector3.Distance (controller.transform.position, gameObject.transform.position) < 10) {
			float directionX = Mathf.Sign (controller.transform.position.x - gameObject.transform.position.x);
			rb2d.velocity = new Vector2 (directionX * maxSpeed, rb2d.velocity.y);
			if(grounded){
				rb2d.AddForce(new Vector2(0f, jumpForce));
				grounded = false;
			}
		}
	}
}
