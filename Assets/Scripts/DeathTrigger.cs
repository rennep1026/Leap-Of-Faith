using UnityEngine;
using System.Collections;

public class DeathTrigger : MonoBehaviour
{
	private SimplePlatformController controller;

    /*void restart()
    {
		if (controller.hearts > 0)
        	Application.LoadLevel(1);
    }*/

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
			GameObject controllerObject = GameObject.FindWithTag("Player");
			controller = controllerObject.GetComponent<SimplePlatformController> ();
			if (controller.hearts > 0)
				controller.transform.position = controller.initialPosition;
			controller.rb2d.velocity = new Vector2 (0, 0);
			controller.blind = false;
			controller.blindText.SetActive(false);
			controller.blanketActive = false;
			controller.blanket.SetActive(false);
			controller.loseHeart();
        }
    }
}
