using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField] Transform _followTarget;
    Vector3 offset;

    private void Start()
    {
        offset = transform.position - _followTarget.position;
    }

    void Update()
    {
        transform.position = _followTarget.position + offset;
    }
}
