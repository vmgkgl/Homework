using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowCounter : MonoBehaviour
{
    void Update()
    {
        GetComponent<Text>().text = GameCounter.value.ToString();
    }
}
