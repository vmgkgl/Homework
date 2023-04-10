using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public string targetObjectName; 
    public float speed = 1; 

    GameObject targetObject;
    Rigidbody2D rbody;

    void Start()
    { 
        targetObject = GameObject.Find(targetObjectName);
        rbody = GetComponent<Rigidbody2D>();
        rbody.gravityScale = 0;
        rbody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void FixedUpdate()
    { 
        Vector3 dir = (targetObject.transform.position - this.transform.position).normalized;
      
        float vx = dir.x * speed;
        float vy = dir.y * speed;
        rbody.velocity = new Vector2(vx, vy);
     
        this.GetComponent<SpriteRenderer>().flipX = (vx < 0);
    }
}
