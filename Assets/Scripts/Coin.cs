using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour
{
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
            controller.UpdateScore();
            Destroy(gameObject);                  
        }
    }
}
