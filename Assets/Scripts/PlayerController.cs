using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerBD;
    public float speed = 5;
    public GameObject focalPoint;
    public bool hasPowerup = false;
    // Start is called before the first frame update
    void Start()
    {
        playerBD = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        playerBD.AddForce(focalPoint.transform.forward * verticalInput * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
 
        if (other.gameObject.CompareTag("Powerup"))
        {
            
            Destroy(other.gameObject);
            hasPowerup = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Collide with enemy");
        }
    }
}
