using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//�����, ������� ����� �����������, ��� ������� ������� ������������ �������� �������: https://www.youtube.com/watch?v=AQpDtrNJAEU&t=1130s

public class LockLevel : MonoBehaviour
{
    public Button[] LevelButtons;
    public GameObject[] Locks;
    public GameObject[] LevelText;

   // public Button[] UnavailableLevels;//************������� ���� ������ �����,����� ����� ����� ��������� ������ � ������ ������ �������� � �������� ������� �� ����� � ������� ������ �� ������� ������ ������************////

    private bool levellock;

    private void Start()
    {
        //���������� ���� ����� ��������� �������� ������ ���������� ������ � ����� ����
        int levelReached = PlayerPrefs.GetInt("levelReached", 1); //�� �����, ����� ��� ����������� ������� �� ��������� ��� ����� �������. �� ������ ��� ���, ��� ���� �� ������� ������ �� ������ � ����, � ��� ���������� ����� ����������� �������� ������ � ������ level reached, � �� ��� �� ������, ��� ������ ������ �������� 1, � ������� ��� �������� ��� ������ ������ �� ������ ������, ��� ����� ����������� ������ ���, ����� ����� ����� ������ � ����

        for (int i = 0; i < LevelButtons.Length; i++)
        {
            //���� � ���� ������� ������(������ ������) ���� ������ ������, �������� �� ��� �� ��������, �� ����� ������� ��� ������ ���������������
            if (i + 1 > levelReached)//��, �������, ��� ������ ���������� � ����, �, ��������, ��� ����������� ������� ���������� � �������, ������� �� ������ ������ �������� ������� � ������, ����� ������� ��� ��������� ��������������
            {
                LevelButtons[i].interactable = false;
                
            }
            if (i + 1 < levelReached)//�������, ��������� �������� ����������� ������ �������, ������� ������ �����
            {
                LevelButtons[i].enabled = false;
            }

        }

        for (int i = 0; i < Locks.Length; i++)
        {
            Locks[i].SetActive(true);

            if (LevelButtons[i + 1].interactable == true)
            {
                Locks[i].SetActive(false);
            }
        }


        for (int i = 0; i < LevelText.Length; i++)
        {
            LevelText[i].SetActive(false);

            if (LevelButtons[i + 1].interactable == true)
            {
                LevelText[i].SetActive(true);
            }
        }

        //for (int i = 0; i < UnavailableLevels.Length; i++)//************������� ���� ���� �����,����� ����� ����� ��������� ������ � ������ ������ �������� � �������� ������� �� ����� � ������� ������ �� ������� ������ ������ ************//
        //{
        //    UnavailableLevels[i].interactable = false;
        //}

    }


    public void ResetBtn()
    {
        PlayerPrefs.DeleteAll();
    }

}
