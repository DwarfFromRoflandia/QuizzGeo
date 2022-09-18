using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchQuestion : MonoBehaviour
{
    [SerializeField] private GameObject resultPanel;
    public List<GameObject> QuestionsList = new List<GameObject>();
    private bool endLevel;

    public int countQuestion;

    private void Start()
    {
        resultPanel.SetActive(false);
    }
    private void Update()
    {
        for (int i = 0; i < 10; i++)
        {
            switch (countQuestion)
            {
                case 0:
                    QuestionsList[0].SetActive(true);
                    break;
                case 1:
                    QuestionsList[0].SetActive(false);
                    QuestionsList[1].SetActive(true);
                    break;
                case 2:
                    QuestionsList[1].SetActive(false);
                    QuestionsList[2].SetActive(true);
                    break;
                case 3:
                    QuestionsList[2].SetActive(false);
                    QuestionsList[3].SetActive(true);
                    break;
                case 4:
                    QuestionsList[3].SetActive(false);
                    QuestionsList[4].SetActive(true);
                    break;
                case 5:
                    QuestionsList[4].SetActive(false);
                    QuestionsList[5].SetActive(true);
                    break;
                case 6:
                    QuestionsList[5].SetActive(false);
                    QuestionsList[6].SetActive(true);
                    break;
                case 7:
                    QuestionsList[6].SetActive(false);
                    QuestionsList[7].SetActive(true);
                    break;
                case 8:
                    QuestionsList[7].SetActive(false);
                    QuestionsList[8].SetActive(true);
                    break;
                case 9:
                    QuestionsList[8].SetActive(false);
                    QuestionsList[9].SetActive(true);
                    break;
                case 10:
                    QuestionsList[9].SetActive(true);
                    endLevel = true;
                    break;
                default:
                    break;
            }
        }

        OnResultPanel();


    }

    private void OnResultPanel()
    {
        if (endLevel)
        {
            resultPanel.SetActive(true);
        }      
    }
}
