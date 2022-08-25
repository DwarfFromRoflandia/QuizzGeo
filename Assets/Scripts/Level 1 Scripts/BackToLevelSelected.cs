using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class BackToLevelSelected : MonoBehaviour
{
    public int levelToUnlock;//����������, ������� ����� �������������� ��� ����, ����� �������������� ��������� �������

    private void Update()
    {
        TransferValueLevelToUnlock.valueLevelToUnlock = levelToUnlock;
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
        Debug.Log("���������� ���� � ���� ������ �������: " + TransferStars.transferStras);
        levelToUnlock++;//������ ��������� ������ ���������� ��� ����, ����� ����� ����� ����� � ���� ������ ������, ��� ��� �������� ��������� �������
    }

    private void OnEnable()
    {
        if (TransferValueLevelToUnlock.valueLevelToUnlock != 0)
        {
            levelToUnlock = TransferValueLevelToUnlock.valueLevelToUnlock;
        }
    }
    private void OnDestroy()
    {
        TransferValueLevelToUnlock.valueLevelToUnlock = levelToUnlock;
    }
}
