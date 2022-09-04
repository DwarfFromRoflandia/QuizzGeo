using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerQuestions : MonoBehaviour
{
    [SerializeField] private GameObject questionOne;
    [SerializeField] private GameObject questionTwo;
    [SerializeField] private GameObject questionThree;
    [SerializeField] private GameObject questionFour;
    [SerializeField] private GameObject questionFive;
    [SerializeField] private GameObject questionSix;
    [SerializeField] private GameObject questionSeven;
    [SerializeField] private GameObject questionEight;
    [SerializeField] private GameObject questionNine;
    [SerializeField] private GameObject questionTen;

    public static List<GameObject> PullQuestions = new List<GameObject>();
    private void Start()
    {
        PullQuestions.Add(questionOne);
        PullQuestions.Add(questionTwo);
        PullQuestions.Add(questionThree);
        PullQuestions.Add(questionFour);
        PullQuestions.Add(questionFive);
        PullQuestions.Add(questionSix);
        PullQuestions.Add(questionSeven);
        PullQuestions.Add(questionEight);
        PullQuestions.Add(questionNine);
        PullQuestions.Add(questionTen);

        EventManager.SpawnQuestionEvent.AddListener(SpawnQuestion);
    }

    public void SpawnQuestion()
    {
        //int rand = Random.Range(0, PullQuestions.Count);
        //for (int i = 0; i < PullQuestions.Count; i++)
        //{
        //    Instantiate(PullQuestions[rand]);
        //}
        
        //Debug.Log("Instantiate");
    }
}
