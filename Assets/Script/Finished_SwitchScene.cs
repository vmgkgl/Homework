using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // �� ��ȯ�� �ʿ� 

// ī���Ͱ� �������̸� ���� ��ȯ�Ѵ� 
public class OnCountFinished_SwitchScene : MonoBehaviour
{

    public int lastCount = 3; // ī������ ������ : Inspector�� ����
    public string sceneName = ""; // �� �̸���Inspector�� ����

    void FixedUpdate() // ��� �����Ѵ�
    {
        // ī���Ͱ� �������� �Ǹ� 
        if (GameCounter.value == lastCount)
        {
            // ���� ��ȯ�Ѵ� 
            SceneManager.LoadScene(sceneName);
        }
    }
}
