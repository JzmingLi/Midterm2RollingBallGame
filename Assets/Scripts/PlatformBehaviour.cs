using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBehaviour : MonoBehaviour
{
    public void Fall()
    {
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.velocity = Vector3.down * 10;
        rb.AddTorque(Random.Range(-50, 50), Random.Range(-50, 50), Random.Range(-50, 50));
        Destroy(gameObject, 2);
    }
}
