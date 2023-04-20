using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CountSwitchScene : MonoBehaviour
{
    public int lastCount = 10;
    public string sceneName = "";

    private void FixedUpdate()
    {
        if (GameCounter.value == lastCount)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
