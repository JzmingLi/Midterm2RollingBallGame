using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Vector3 _constantVelocity;
    [SerializeField] float _speed;
    Rigidbody _rb;
    bool goingXNotZ;
    List<GameObject> platforms;

    // Start is called before the first frame update
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
        goingXNotZ = true;
        _constantVelocity = Vector3.right * _speed;
        platforms = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            goingXNotZ = !goingXNotZ;
            if (goingXNotZ) _constantVelocity = Vector3.right * _speed;
            else _constantVelocity = Vector3.forward * _speed;
        }
    }

    void FixedUpdate()
    {
        _rb.velocity = _constantVelocity;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Diamond"))
        {
            Destroy(other.gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!platforms.Contains(collision.gameObject) && collision.gameObject.CompareTag("Platform")) platforms.Add(collision.gameObject);
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            platforms.Remove(collision.gameObject);
            collision.gameObject.GetComponent<PlatformBehaviour>().Invoke("Fall", 0.5f);
            if (platforms.Count == 0) Invoke("GameOver",0.2f);
        }
    }

    void GameOver()
    {
        _constantVelocity = Vector3.down * _speed;
        _rb.velocity = _constantVelocity;
        GameObject.Find("MainCamera").GetComponent<CameraBehaviour>().enabled = false;
        GameObject.Find("PlatformSpawner").GetComponent<PlatformSpawner>().enabled = false;
        enabled = false;
    }
}
