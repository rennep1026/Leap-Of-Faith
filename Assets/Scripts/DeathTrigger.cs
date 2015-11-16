using UnityEngine;
using System.Collections;

public class DeathTrigger : MonoBehaviour
{
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
            Invoke("restart", 0.25f);
        }
    }
}
