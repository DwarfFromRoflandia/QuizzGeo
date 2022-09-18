using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SpawnerQuestion : MonoBehaviour
{
    /*
     ������ ������ �������� ������, � ������� ����� ������������� � ��������� ������� �������.
     ����� ������� �� ����� ������� ������ ���� ������� ���, ����� ��� ��������� �� ������ �� ����� �������,
     �� � �� ���� �������, ������ ��� ������, ����� ��� �� ������� �� ���������� � ������� �������.
     */

    public List<GameObject> QuestionList = new List<GameObject>();

    //private GameObject mainObject;
    private AnswerScriptBtn testGameObject;

    private void Awake()
    {
        //mainObject = GameObject.FindGameObjectWithTag("MainObject");
        int randomQuestion;

        //���� ���� ���������� 10 ��� � �� �������� ��������� ������ QuestionList ����������� ���������� � ��������� �������, ������������ ���� �� �����.
        for (int i = 0; i < 1; i++)
        {
            do
            {
                randomQuestion = Random.Range(0, PullQuestionArray.instance.PullQuestionsForSimpleLevel.Count);//� ���������� randomQuestion ����������� ��������� �������� �� 0 �� ���� ����� ������
            }
            while (QuestionList.Contains(PullQuestionArray.instance.PullQuestionsForSimpleLevel[randomQuestion]));//����� Contains() ����� true � ��� ������, ���� ������ ����� ����������� ������� (������ �������� ����� �������� ���������� randomQuestion)
            {
                QuestionList.Add(PullQuestionArray.instance.PullQuestionsForSimpleLevel[randomQuestion]);
            }

        }

        for (int i = 0; i < 1; i++)
        {
            Instantiate(QuestionList[0]);//��� ������ ���� ������ ������ �� �����
        }

        Debug.Log("���������� ��������� � ����� QuestionList: " + QuestionList.Count);
    }   
}
