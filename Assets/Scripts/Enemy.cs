using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	private SimplePlatformController controller;
	
	void Start()
	{
		GameObject controllerObject = GameObject.FindWithTag("Player");
		controller = controllerObject.GetComponent<SimplePlatformController>();
	}
	
	// Update is called once per frame
	void OnCollisionEnter2D (Collision2D other)
	{ 
		if (other.gameObject.CompareTag("Player") && !controller.blanketActive)
		{
			controller.loseHeart();
			//controller.rb2d.AddForce(new Vector2(controller.rb2d.velocity.x * -10000, controller.rb2d.velocity.y * -10000));
		}
	}
}
