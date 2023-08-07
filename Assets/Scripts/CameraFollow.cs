using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform objectToFollow;
    Vector3 offset;
    void Start()
    {
        offset = transform.position - objectToFollow.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = objectToFollow.position + offset;
    }
}
