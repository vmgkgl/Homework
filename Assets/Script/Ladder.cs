using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    public float speed = 3;
    bool isActive = false;
    Boy boy;
    Rigidbody2D rigid2D;
    private void Start()
    {
        boy = GameObject.FindWithTag("Player").GetComponent<Boy>();
        rigid2D = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            rigid2D.gravityScale = 1f;
            isActive = false;
        }
    }

    void Update()
    {
        if (isActive && Input.GetKey(KeyCode.UpArrow))
        {
            rigid2D.gravityScale = 0f;
            rigid2D.velocity = new Vector2(0f, 0f);
            boy.transform.Translate(Vector2.up * Time.deltaTime * speed);
        }
        if (isActive && Input.GetKey(KeyCode.DownArrow))
        {
            rigid2D.gravityScale = 0f;
            rigid2D.velocity = new Vector2(0f, 0f);
            boy.transform.Translate(Vector2.down * Time.deltaTime * speed);
        }
    }
}
