using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class BackToLevelSelected : MonoBehaviour
{
    //���� ��� ���������� �� ����� ������������ ��� ����, ����� �������������� ��������� ������� ��� ����������� �����������. �� ����� ������������ ��� ����������: int ��� string � ������ LevelEnd, ��� ������������ PlayerPrefs. Int ���������� ������ ��������� �����, ������� ����� �������������, � string �������� ��� �����, ������� ����� ��������������. ������������ ����� ���-�� ����
    public string nextLevel = "Level2";
    public int levelToUnlock = 1;

    private void Start()
    {
        levelToUnlock++;
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);

        LevelEnd();

        Debug.Log("���������� ���� � ���� ������ �������: " + TransferStars.transferStras);
    }

    private void LevelEnd()
    {
        
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
    }


}
