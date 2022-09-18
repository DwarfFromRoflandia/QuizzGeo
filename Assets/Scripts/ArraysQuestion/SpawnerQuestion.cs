using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SpawnerQuestion : MonoBehaviour
{
    /*
     данный скрипт содержит массив, в который будут присваиватьс€ в рандомном пор€дке вопросы.
     ƒалее вопросы из этого массива должны быть удалены так, чтобы они удалились не только из этого массива,
     но и из того массива, откуда они пришли, чтобы эти же вопросы не по€вл€лись в будущих уровн€х.
     */

    public List<GameObject> QuestionList = new List<GameObject>();

    //private GameObject mainObject;
    private AnswerScriptBtn testGameObject;

    private void Awake()
    {
        //mainObject = GameObject.FindGameObjectWithTag("MainObject");
        int randomQuestion;

        //цикл ниже отработает 10 раз и он позволит заполнить список QuestionList уникальными элементами в рандомном пор€дке, отличающихс€ друг от друга.
        for (int i = 0; i < 1; i++)
        {
            do
            {
                randomQuestion = Random.Range(0, PullQuestionArray.instance.PullQuestionsForSimpleLevel.Count);//в переменную randomQuestion присваиваем рандомное значение от 0 до всей длины списка
            }
            while (QuestionList.Contains(PullQuestionArray.instance.PullQuestionsForSimpleLevel[randomQuestion]));//метод Contains() вернЄт true в том случае, если список имеет определЄнный элемент (индекс которого равен значению переменной randomQuestion)
            {
                QuestionList.Add(PullQuestionArray.instance.PullQuestionsForSimpleLevel[randomQuestion]);
            }

        }

        for (int i = 0; i < 1; i++)
        {
            Instantiate(QuestionList[0]);//при помощи цикл создаЄм объект на сцене
        }

        Debug.Log(" ќличество элементов в листе QuestionList: " + QuestionList.Count);
    }   
}
