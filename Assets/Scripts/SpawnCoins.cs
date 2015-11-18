using UnityEngine;
using System.Collections;

public class SpawnCoins : MonoBehaviour
{
    public Transform[] coinSpawns;
    public GameObject coin;

	void Start ()
    {
        Spawn();
	}
	
    void Spawn()
    {
        for (int i = 0; i < coinSpawns.Length; ++i)
        {
            int coinFlip = Random.Range(0, 2); //Check whether to spawn coin or not.
            if (coinFlip > 0){
				Vector3 parentPlatform = coinSpawns[i].parent.gameObject.transform.position;
				Vector3 newPos = parentPlatform;
				newPos[1] += 2f;
				newPos[0] += i*2-1f;
                Instantiate(coin, newPos, Quaternion.identity);
			}
        }
    }
}
