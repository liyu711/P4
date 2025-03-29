using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerBD;
    public float speed = 5;
    public GameObject focalPoint;
    public bool hasPowerup = false;
    private float powerupStrength = 15.0f;
    private float powerupDuration = 7;
    public GameObject powerUpIndicator;


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
        powerUpIndicator.transform.position = transform.position + new Vector3(0, -0.436f, 0);
        playerBD.AddForce(focalPoint.transform.forward * verticalInput * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
 
        if (other.gameObject.CompareTag("Powerup"))
        {
            
            Destroy(other.gameObject);
            hasPowerup = true;
            powerUpIndicator.gameObject.SetActive(true);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyBD = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayDirection = collision.gameObject.transform.position - transform.position;
            enemyBD.AddForce(awayDirection * powerupStrength, ForceMode.Impulse);
            
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerUpIndicator.gameObject.SetActive(false);
    }
}
