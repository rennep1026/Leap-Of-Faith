using UnityEngine;
using System.Collections;

public class Enemy_Waypoint : MonoBehaviour {

	public Vector3 patrol1;
	public Vector3 patrol2;

	private SimplePlatformController controller;
	private float maxSpeed = 3f;
	private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		GameObject controllerObject = GameObject.FindWithTag("Player");
		controller = controllerObject.GetComponent<SimplePlatformController>();
		rb2d = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate () {

	}
}
