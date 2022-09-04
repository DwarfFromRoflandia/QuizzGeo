using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Test : MonoBehaviour
{
    private static List<GameObject> question = new List<GameObject>();
    private void Start()
    {
        int randomQuestion = Random.Range(0, SpawnerQuestions.PullQuestions.Count);
        question.Add(SpawnerQuestions.PullQuestions[randomQuestion]);
        question.Add(gameObject);
        question.Add(gameObject);
        


        for (int i = 0; i < SpawnerQuestions.PullQuestions.Count; i++)
        {
            int rand = Random.Range(0, i);
            Instantiate(SpawnerQuestions.PullQuestions[rand]);
        } 
    }

    private void Update()
    {
        
    }

}
