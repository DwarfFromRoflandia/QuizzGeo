using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionArray : MonoBehaviour
{
    /*
     ������ ������� ���� ����� ��������� ��� �������(����� ���� ������ ������ �� ����, ������� ����� ����� ������� � ����). 
     ���� ���������� ������ ����. ������ ������ ����� ��������� � ���� �������, ����������� ��� ����������� ���� �������.
     �������� (������� GameObject'��) �� ������ �������� ����� ������������� � ������ �������, ����������� ��� �� ����� �������.
     */


    public List<GameObject> QuestionArrayForSimpleLevel = new List<GameObject>();
    void Start()
    {
        PullQuestionArray.instance.PullQuestionsForSimpleLevel = QuestionArrayForSimpleLevel;
    }
}
