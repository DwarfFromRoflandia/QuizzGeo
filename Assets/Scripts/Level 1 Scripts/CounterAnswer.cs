using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CounterAnswer : MonoBehaviour
{
 
    private int score;
    private CounterOfCorrectAnswer counterOfCorrectAnswer;

    public int Score { get => score; }//�������� ��� ����� �������������� ��� ����, ����� ������������ ���������� ���� �� ����� ������ � ������� StarsCount


    public void CountScore()
    {
        score++;
    }

    private void Start()
    {
        counterOfCorrectAnswer = GetComponent<CounterOfCorrectAnswer>();  
        TransferStars.transferStras = score;//����� ����������� � �������� transferStras, �������� score ��� ����, ����� ����� � ���� ������ ������� �����, ������� �� ���� ������ �� ��� ��� ���� �������
        CountTransferGem();
    }

    private void CountTransferGem()
    {
        if (score < 3)
        {      
            Debug.Log("*********0*********"); 
        }
        else if (score >= 3 && score < 6)
        {
            Bank.instance.PlusThreeGem();

            counterOfCorrectAnswer.PointsThree();
            Debug.Log("*********3*********");
        }
        else if(score >= 6 && score < 9)
        {
            Bank.instance.PlusSixGem();

            counterOfCorrectAnswer.PointsSix();
            Debug.Log("*********6*********");
        }
        else if (score >= 9)
        {
            Bank.instance.PlusNineGem();

            counterOfCorrectAnswer.PointsNine();
            Debug.Log("*********9*********");
        }
    }




}

