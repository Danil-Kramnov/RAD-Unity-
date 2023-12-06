using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeScript : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            explode();
        }
    }

    private void explode()
    {
        Collider[] victims = Physics.OverlapSphere(transform.position, 10);

        foreach (Collider victim in victims)
        {
            Rigidbody rb_victim = victim.GetComponent<Rigidbody>();
            if (rb_victim != null)
                rb_victim.AddExplosionForce(2000, transform.position, 10);
        }
    }
}