using UnityEngine;
using System.Collections;

public class SpawnClouds : MonoBehaviour
{
    public GameObject clouds;

	void Start ()
    {
        Spawn();
	}

    void Spawn()
    {
        Instantiate(clouds, transform.position, Quaternion.identity);
    }
}
