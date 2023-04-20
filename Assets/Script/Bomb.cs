using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float deleteTime = 5.0f;

    SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        Throw.currentCount++;

        Destroy(gameObject, deleteTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject, deleteTime = 5.0f);
    }
    private void OnDestroy()
    {
        Throw.currentCount--;
    }
}