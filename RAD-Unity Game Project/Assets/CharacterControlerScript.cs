using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterControllerScript : MonoBehaviour

{
    Vector3 velocity;
    Vector2 acceleration;

    float rateOfRotation = 0.018f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {   if (Input.GetKey(KeyCode.W)) { velocity = transform.forward; }
        if (Input.GetKey(KeyCode.S)) { velocity = -transform.forward; }
        if (Input.GetKey(KeyCode.D)) { transform.Rotate(Vector3.up, rateOfRotation * Time.deltaTime); }
        if (Input.GetKey(KeyCode.A)) { }

        transform.position += velocity * Time.deltaTime;
        transform.velocity += acceleration * Time.deltaTime;
        

    }
}

