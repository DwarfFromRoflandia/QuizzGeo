using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullQuestionArray
{
    /*
     ������ ������� ���� ����� ��������� ��� �������(����� ���� ������ ������ �� ����, ������� ����� ����� ������� � ����). 
     ���� ���������� ������ ����. ������ ������ ����� ��������� � ���� �������, ����������� ��� ����������� ���� �������.
     �������� �� ������ ������� ����� ������������� � �������, ������� ����������� � �������. ��� �����, ��������� �����, � �������
     ����� ���������� � ��������� ������� ������� �� ������� ����� ������ ��������.
     */


    public List<GameObject> PullQuestionsForSimpleLevel = new List<GameObject>();

    //���������� ������� ��������, ������� �������� ���������� ������ �������� � ������ ����� (����� � ��������).
    public static PullQuestionArray instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new PullQuestionArray();
            }
            return _instance;
        }
    }

    private static PullQuestionArray _instance;
}
