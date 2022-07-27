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

    private int countGemInTheResultPanel;

    private void Start()
    {
        
    }

    private void Update()
    {
        textPoints.text = points.ToString();
        
    }

    //ниже три метода будут использоваться для подсчёта гемов, КАК СТРОКУ, на итоговой панели после прохождения уровня. Вызываться эти методы будут в скрипте CounterAnswer
    public void PointsThree()
    {
        // points += 3;

        animationOnTheResultPanel.StartCoroutine(animationOnTheResultPanel.CoroutineAnimationOfGettingThreeDiamondsEarned());

    }

    public void PointsSix()
    {
        // points += 6;

        animationOnTheResultPanel.StartCoroutine(animationOnTheResultPanel.CoroutineAnimationOfGettingSixDiamondsEarned());
    }

    public void PointsNine()
    {
        // points += 9;

        animationOnTheResultPanel.StartCoroutine(animationOnTheResultPanel.CoroutineAnimationOfGettingNineDiamondsEarned());
    }



    //ниже три метода нужны строго для того, чтобы подсчитывать количество гемов на итоговом экране в кажом уровне(этот экран появляется после того, как игрок ответил на все 10 вопросов)  

    //private void CountPoints()
    //{
    //    if (points >= 3 && points < 6)
    //    {
    //        countGemInTheResultPanel += 3;
    //    }
    //    else if (points >= 6 && points < 9)
    //    {
    //        countGemInTheResultPanel += 6;
    //    }
    //    else if (points >= 9)
    //    {
    //        countGemInTheResultPanel += 9;
    //    }
    //}

}
