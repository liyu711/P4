using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed = 10;

    public float speed = 5;
    private Rigidbody playerBD;
    // Start is called before the first frame update
    void Start()
    {
        playerBD = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.Rotate(Vector3.up, horizontalInput * Time.deltaTime * rotationSpeed);
        playerBD.AddForce(Vector3.forward * verticalInput * speed);
    }
}
