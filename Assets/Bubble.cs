using UnityEngine;
using System.Collections;

public class Bubble : MonoBehaviour {

    //private SimplePlatformController controller;
    private Collider2D player_collider;
    //private Enemy enemy;
    //private Enemy_Track enemy1;
    //private Enemy_Waypoint enemy2;
    //private GameObject[] enemies;

    void Start()
    {
        GameObject controllerObject = GameObject.FindWithTag("Player");
        //controller = controllerObject.GetComponent<SimplePlatformController>();
        //GameObject a = GameObject.Find("Enemy_Snowman");
        player_collider = controllerObject.GetComponent<Collider2D>();
        //enemy.GetComponent<Enemy>();
        //enemy1 = enemy1.GetComponent<Enemy_Track>();
        //enemy2 = enemy2.GetComponent<Enemy_Waypoint>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            player_collider.enabled = false;
            waitThreeSeconds();
            player_collider.enabled = true;

        }
    }

    //void OnTriggerEnter2D(Collider2D bubble)
    //{
    //    if (bubble.gameObject.CompareTag("Player"))
    //    {
    //        Destroy(gameObject);
    //        enemy.enabled = false;
    //        enemy1.enabled = false;
    //        enemy2.enabled = false;
    //        waitThreeSeconds();
    //        enemy.enabled = true;
    //        enemy1.enabled = true;
    //        enemy2.enabled = true;
    //    }
    //}

    IEnumerator waitThreeSeconds()
    {
        yield return new WaitForSeconds(3.0f);
    }


    //   // Use this for initialization
    //   void Start () {

    //}

    //// Update is called once per frame
    //void Update () {

    //}
}
