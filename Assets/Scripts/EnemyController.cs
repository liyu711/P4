using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 0.1f;
    private Rigidbody enemyBD;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        enemyBD = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 chaseDirection = (player.transform.position - transform.position).normalized;
        enemyBD.AddForce(chaseDirection * speed);
    }
}
