using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionArray : MonoBehaviour
{
    /*
     данный кодовый файл будет содержать три массива(может быть больше исходя из того, сколько будет видов уровней в игре). 
     Пока реализован только один. Каждый массив будет содержать в себе вопросы, характерные для конкретного вида уровней.
     Элементы (префабы GameObject'ов) из данных массивов будут присваиваться в другие массивы, характерные для их видов уровней.
     */


    public List<GameObject> QuestionArrayForSimpleLevel = new List<GameObject>();
    void Start()
    {
        PullQuestionArray.instance.PullQuestionsForSimpleLevel = QuestionArrayForSimpleLevel;
    }
}
