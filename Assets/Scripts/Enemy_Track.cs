using UnityEngine;
using System.Collections;

public class Enemy_Track : MonoBehaviour {

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
			Vector3 currPos = gameObject.transform.position;
			float directionX = Mathf.Sign (controller.transform.position.x - gameObject.transform.position.x);
			Vector3 targetPos = new Vector3(currPos[0]+(.2f*directionX),currPos[1],currPos[2]);
			Vector3 down = transform.TransformDirection(Vector3.down);
			bool checkForFloor = Physics.Raycast(targetPos, down, Mathf.Infinity, 12);
			Debug.Log("CurrPos " + currPos);
			Debug.Log("TargetPos " + targetPos);
			if(checkForFloor){
				rb2d.velocity = new Vector2 (directionX * maxSpeed, rb2d.velocity.y);
				if(grounded){
					rb2d.AddForce(new Vector2(0f, jumpForce));
					grounded = false;
				}
			}
		}
	}
}
