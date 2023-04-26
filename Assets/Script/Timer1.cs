using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer1 : MonoBehaviour
{
    GameObject timerText;
    float startTime = 75.0f;
    public float time = 75.0f;
    float lastTime = 5f;
    public Slider timerBar;
    public GameObject x;
    bool isStart = false;
    void Start()
    {
        this.timerText = GameObject.Find("Text1");
    }

    void Update()
    {
        this.time -= Time.deltaTime;
        timerBar.value = time / startTime;
        this.timerText.GetComponent<Text>().text = this.time.ToString("F1");
        if (time <= lastTime&&isStart==false)
        {
            StartCoroutine(y());
        }
        if (this.time <= 0.0f)
        {
            SceneManager.LoadScene("gameover");
        }
    }
    IEnumerator y()
    {
        isStart= true;
        float t = 0f;
        
        Vector3 oriScale = x.transform.localScale;
        Vector3 ori = Camera.main.transform.localPosition;
        while (true)
        {
            t+= Time.deltaTime;
            x.transform.localScale = Vector3.Lerp(oriScale, new Vector3(13f, 13f, 13f),(lastTime-time)* (lastTime - time)*(lastTime - time) * (lastTime - time) / Mathf.Pow(lastTime,4f));

            Camera.main.transform.localPosition = ori+ new Vector3(Random.Range(0f, 0.5f / time), Random.Range(0f, 0.5f / time), 0f);
            yield return null;
        }
    }
}