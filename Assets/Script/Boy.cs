using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boy : MonoBehaviour
{
    public float speed = 3; 
    public float jumppower = 8;  

    float vx = 0;
    float vy = 0;

    bool leftFlag = false; 
    bool pushFlag = false; 
    bool jumpFlag = false; 
    bool groundFlag = false;
    Rigidbody2D rbody;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        rbody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void Update() 
    {
        vx = 0;
        vy = 0;
        if (Input.GetKey("right")) 
        {
            vx = speed; 
            leftFlag = false;
        }
        if (Input.GetKey("left")) 
        { 
            vx = -speed; 
            leftFlag = true;
        }
        
        
        if (Input.GetKey("space") && groundFlag)
        {
            if (pushFlag == false)
            {
                jumpFlag = true;  
                pushFlag = true; 
            }
        }
        else
        {
            pushFlag = false; 
        }
    }
    void FixedUpdate() 
    {
      
        rbody.velocity = new Vector2(vx, rbody.velocity.y);
      
        this.GetComponent<SpriteRenderer>().flipX = leftFlag;
       
        if (jumpFlag)
        {
            jumpFlag = false;
            rbody.AddForce(new Vector2(0, jumppower), ForceMode2D.Impulse);
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {  
        groundFlag = true;

        if(Input.GetKey("up"))
        {
            Debug.Log("dd");
            vy = speed;

        }
    }
    void OnTriggerExit2D(Collider2D collision)
    { 
        groundFlag = false;
    }
}
