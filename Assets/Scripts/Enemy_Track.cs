using UnityEngine;
using System.Collections;

public class Enemy_Track : MonoBehaviour {

	private SimplePlatformController controller;
	private float maxSpeed = 3f;
	private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		GameObject controllerObject = GameObject.FindWithTag("Player");
		controller = controllerObject.GetComponent<SimplePlatformController>();
		rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (controller.transform.position, gameObject.transform.position) < 10) {
			float directionX = Mathf.Sign(controller.transform.position.x - gameObject.transform.position.x);
			rb2d.velocity = new Vector2(directionX * maxSpeed, rb2d.velocity.y);
		}

	}
}
