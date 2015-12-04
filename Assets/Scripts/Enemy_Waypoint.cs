using UnityEngine;
using System.Collections;

public class Enemy_Waypoint : MonoBehaviour {

	public float left;
	public float right;

	private float maxSpeed = 3f;
	private Rigidbody2D rb2d;
	private Vector3 startPoint;
	private float point1;
	private float point2;
	private float currentDirection = -1f;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		startPoint = gameObject.transform.position;
		point1 = startPoint[0] + left;
		point2 = startPoint[0] + right;
	}
	
	void FixedUpdate () {
		if (gameObject.transform.position [0] < point1 || gameObject.transform.position [0] > point2) {
			currentDirection *= -1f;
		}
		rb2d.velocity = new Vector2 (currentDirection * maxSpeed, rb2d.velocity.y);
	}
}
