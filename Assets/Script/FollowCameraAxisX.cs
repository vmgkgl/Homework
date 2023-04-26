using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCameraAxisX : MonoBehaviour
{
    float originalX;
    void Start()
    {
        originalX = transform.position.x;
    }
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x = originalX + Camera.main.transform.position.x;
        transform.position = pos;
    }
}