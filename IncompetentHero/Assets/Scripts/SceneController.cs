using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    public void SwitchScene()
    {
        SceneManager.LoadScene("StageSelect");
    }

    public void CutScene1End() // �ƾ� 1 ������ �������� ����Ʈ ȭ������
    {
        SceneManager.LoadScene("StageSelect");
    }
}
