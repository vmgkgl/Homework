using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer1 : MonoBehaviour
{
    GameObject timerText;
    float startTime = 90.0f;
    public float time = 90.0f;
    float lastTime = 5f;
    public Slider timerBar;
    public GameObject 공포의때밀이군주오브젝트;
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
        if (time <= lastTime && isStart == false)
        {
            StartCoroutine(공포의때밀이군주());
        }
        if (this.time <= 0.0f)
        {
            SceneManager.LoadScene("gameover");
        }
    }
    IEnumerator 공포의때밀이군주()
    {
        isStart = true;
        float t = 0f;

        Vector3 oriScale = 공포의때밀이군주오브젝트.transform.localScale;
        Vector3 ori = Camera.main.transform.localPosition;
        while (true)
        {
            t += Time.deltaTime;
            공포의때밀이군주오브젝트.transform.localScale = Vector3.Lerp(oriScale, new Vector3(13f, 13f, 13f), (lastTime - time) * (lastTime - time) * (lastTime - time) * (lastTime - time) / Mathf.Pow(lastTime, 4f));

            Camera.main.transform.localPosition = ori + new Vector3(Random.Range(0f, 0.5f / time), Random.Range(0f, 0.5f / time), 0f);
            yield return null;
        }
        yield return null;
    }
}