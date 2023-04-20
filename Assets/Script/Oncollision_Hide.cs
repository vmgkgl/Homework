using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oncollision_Hide : MonoBehaviour
{
    public string targetObjectName;
    public string hideObjectName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == targetObjectName)
        {
            GameObject hideObject = GameObject.Find(hideObjectName);
            hideObject.SetActive(false);
        }
    }
}
