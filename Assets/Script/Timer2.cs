using UnityEngine;
using UnityEngine.UI;

public class Timer2 : MonoBehaviour
{
    public float timeLeft = 60.0f;
    public Text timerText;

    void Update()
    {
        timeLeft -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(timeLeft / 60.0f);
        int seconds = Mathf.FloorToInt(timeLeft % 60.0f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}