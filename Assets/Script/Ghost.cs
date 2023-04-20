using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public string targetObjectName;
    public float speed = 1;
    public float accSpeed = 1f;

    GameObject targetObject;
    Rigidbody2D rbody;
    void Start()
    {
        targetObject = GameObject.Find(targetObjectName);
        rbody = GetComponent<Rigidbody2D>();
        rbody.gravityScale = 0;
        rbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        accSpeed = Random.Range(1f, 10f);
    }

    private void FixedUpdate()
    {
        Vector3 dir = (targetObject.transform.position - this.transform.position).normalized;
        transform.up = Vector3.Lerp(transform.up, dir, Time.deltaTime * accSpeed);
        transform.position += transform.up * Time.deltaTime * speed;
    }
    void Update()
    {
    }
}
