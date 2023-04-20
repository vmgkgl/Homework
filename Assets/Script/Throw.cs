using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    public static Throw Instance;
    public GameObject newPrefab;
    public int maxCount = 20;
    public static int currentCount = 0;
    public float throwX = 4;
    public float throwY = 8;
    public float offsetY = 1;

    bool pushFlag = false;
    bool leftFlag = false;
    private void Start()
    {
        Instance = this;

    }
    void Update()
    {
        if (Input.GetKey("right"))
        {
            leftFlag = false;
        }
        if (Input.GetKey("left"))
        {
            leftFlag = true;
        }
        if (Input.GetKeyDown("z"))
        {
            if (currentCount < maxCount)
            {
                Vector3 area = this.GetComponent<SpriteRenderer>().bounds.size;
                Vector3 newPos = this.transform.position;
                newPos.y += offsetY;
                GameObject newgameObject = Instantiate(newPrefab);
                newPos.z = 0;
                newgameObject.transform.position = newPos;

                Rigidbody2D rbody = newgameObject.GetComponent<Rigidbody2D>();
                if (leftFlag)
                {
                    rbody.AddForce(new Vector2(-throwX, throwY), ForceMode2D.Impulse);
                }
                else
                {
                    rbody.AddForce(new Vector2(throwX, throwY), ForceMode2D.Impulse);
                }
            }
        }
    }
}
