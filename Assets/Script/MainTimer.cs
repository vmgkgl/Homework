using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    GameObject timerText;
    float time = 30.0f;

    void Start()
    {
        this.timerText = GameObject.Find("Text1");
    }

    void Update()
    {
        this.time -= Time.deltaTime;
        this.timerText.GetComponent<Text>().text = this.time.ToString("F1");

        if (this.time <= 0.0f)
        {
            SceneManager.LoadScene("gameover");
        }
    }
}