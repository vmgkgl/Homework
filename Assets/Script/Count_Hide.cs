using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Count_Hide : MonoBehaviour
{
    public string targetObjectName;
    public int addValue = 1;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == targetObjectName)
        {
            GameCounter.value = GameCounter.value + addValue;
            this.gameObject.SetActive(false);
        }
    }
}
