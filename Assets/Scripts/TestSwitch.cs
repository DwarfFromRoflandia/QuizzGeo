using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSwitch : MonoBehaviour
{
    private SpawnerQuestion spawnerQuestion;

    public string[] array = new string[10];
    void Start()
    {
        spawnerQuestion = GetComponent<SpawnerQuestion>();
        array[0] = "eff";
    }

    
    void Update()
    {
        
    }

    private void QuestionSwitch()
    {
        //switch (array)
        //{
        //    case 0:


        //        break;

        //}

        //for (int i = 0; i < array.Length; i++)
        //{
            
        //}

    }
}
