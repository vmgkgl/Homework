using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float speed = 1;

    Rigidbody2D rbody;

    private void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        rbody.gravityScale = 0;
        rbody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    private void FixedUpdate()
    {
        rbody.velocity = new Vector2(speed, 0);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        speed = -speed;
        this.GetComponent<SpriteRenderer>().flipX = (speed < 0);
    }
}