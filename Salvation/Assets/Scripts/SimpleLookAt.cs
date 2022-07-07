using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleLookAt : MonoBehaviour
{
    public Transform target;

    private void Start()
    {
        target = Camera.main.gameObject.transform;
    }

    private void Update()
    {
        transform.LookAt(target);
    }
}
