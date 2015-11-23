using UnityEngine;
using System.Collections;

public class DeathTrigger : MonoBehaviour
{
	private SimplePlatformController controller;

    void restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
			//GameObject controllerObject = GameObject.FindWithTag("Player");
			//controller = controllerObject.GetComponent<SimplePlatformController> ();
			//controller.loseHeart();
            Invoke("restart", 0.25f);
        }
    }
}
