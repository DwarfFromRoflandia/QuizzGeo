using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterOfCorrectAnswer : MonoBehaviour
{
    [SerializeField] private Text textPoints;

    [SerializeField] private AnimationOnTheResultPanel animationOnTheResultPanel;

    private int points;
    public int Points { get { return points; } set { points = value; } }  

    //���� ��� ������ ����� �������������� ��� �������� �����, ��� ������, �� �������� ������ ����� ����������� ������. ���������� ��� ������ ����� � ������� CounterAnswer
    public void PointsThree()
    {
        animationOnTheResultPanel.StartCoroutine(animationOnTheResultPanel.CoroutineAnimationOfGettingThreeDiamondsEarned());
    }

    public void PointsSix()
    {
        animationOnTheResultPanel.StartCoroutine(animationOnTheResultPanel.CoroutineAnimationOfGettingSixDiamondsEarned());
    }

    public void PointsNine()
    {
        animationOnTheResultPanel.StartCoroutine(animationOnTheResultPanel.CoroutineAnimationOfGettingNineDiamondsEarned());
    }

    private void Update()
    {
        textPoints.text = points.ToString();       
    }
}
