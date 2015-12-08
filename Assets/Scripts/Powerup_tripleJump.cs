using UnityEngine;
using System.Collections;

public class Powerup_tripleJump : MonoBehaviour {

	private SimplePlatformController controller;
	
	void Start()
	{
		GameObject controllerObject = GameObject.FindWithTag("Player");
		controller = controllerObject.GetComponent<SimplePlatformController>();
	}
	
	void OnTriggerEnter2D (Collider2D other)
	{ 
		if (other.gameObject.CompareTag("Player"))
		{            
			controller.powerupTripleJump(true);
			Destroy(gameObject);                  
		}
	}
}
