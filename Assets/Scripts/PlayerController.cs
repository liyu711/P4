using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerBD;
    public float speed = 5;
    public GameObject focalPoint;
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
}
