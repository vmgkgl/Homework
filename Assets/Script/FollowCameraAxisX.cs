using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCameraAxisX : MonoBehaviour
{
    // Start is called before the first frame update
    float originalX;
    void Start()
    {
        originalX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x = originalX + Camera.main.transform.position.x;
        transform.position = pos;
    }
}