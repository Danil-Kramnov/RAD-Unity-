using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainControls : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 velocity, acceleration;
    float rateOfRotation = 180f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        acceleration = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        { acceleration = transform.forward; };

        if (Input.GetKey(KeyCode.S))
        { acceleration = -transform.forward; };

        if (Input.GetKey(KeyCode.D))
        { transform.Rotate(Vector3.up, rateOfRotation * Time.deltaTime); };

        velocity += acceleration * Time.deltaTime;

        transform.position += velocity * Time.deltaTime;
    }
}
