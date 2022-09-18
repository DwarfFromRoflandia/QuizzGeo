using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullQuestionArray
{
    /*
     данный кодовый файл будет содержать три массива(может быть больше исход€ из того, сколько будет видов уровней в игре). 
     ѕока реализован только один.  аждый массив будет содержать в себе вопросы, характерные дл€ конкретного вида уровней.
     Ёлементы из кажого массива будут присваиватьс€ в массивы, которые содержатьс€ в уровн€х. “ем самым, благодар€ этому, в уровн€х
     будут по€вл€тьс€ в рандомном пор€дке вопросы на которые игрок сможет отвечать.
     */


    public List<GameObject> PullQuestionsForSimpleLevel = new List<GameObject>();

    //используем паттерн —инглтон, который позволит передавать ссылку массивов в другие сцены (сцены с уровн€ми).
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
