using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CounterAnswer : MonoBehaviour
{
 
    private int score;
    private CounterOfCorrectAnswer counterOfCorrectAnswer;

    public int Score { get => score; }//свойство это будет использоваться для того, чтобы подсчитывать количество звёзд на самом уровне в скрипте StarsCount


    public void CountScore()
    {
        score++;
    }

    private void Start()
    {
        counterOfCorrectAnswer = GetComponent<CounterOfCorrectAnswer>();  
        TransferStars.transferStras = score;//будем присваивать в значение transferStras, значение score для того, чтобы игрок в меню выбора уровней видел, сколько он звёзд собрад за тот или иной уровень
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

