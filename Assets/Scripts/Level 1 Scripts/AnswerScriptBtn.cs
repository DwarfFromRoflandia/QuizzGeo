using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AnswerScriptBtn : MonoBehaviour
{
    [Header("������ �������")]
    [SerializeField] private Button TheFirstAnswerButton;//� ��� ���������� ����������� ������ ������ ������
    [SerializeField] private Button TheSecondAnswerButton;//� ��� ���������� ����������� ������ ������ ������
    [SerializeField] private Button ThirdAnswerButton;//� ��� ���������� ����������� ������ ������ ������
    [SerializeField] private Button TheFourthAnswerButton;//� ��� ���������� ����������� �������� ������ ������

    [Header("�������� � ��������� ������")]
    [SerializeField] private GameObject ThisQuestion;//� ��� ���������� ����������� ������ �� ������� ��������� ������
    [SerializeField] private GameObject NextQuestion;//� ��� ���������� ����������� ��������� ������
    //[SerializeField] private GameObject ResultPanel;

    [Header("������ ���������� �������")]
    [SerializeField] private float timeToWait; //����������, ���������� �� ���������� ������� �������

    [Header("�������")]
    [SerializeField] private CounterAnswer counter;
    [SerializeField] private StarsCount starsCount;
    [SerializeField] private CounterOfCorrectAnswer counterOfCorrectAnswer;

    [Header("�����")]
    [SerializeField]private LampScript lamp;
    [SerializeField] private GameObject greenLamp;
    [SerializeField] private GameObject redLamp;


    private float WaitTime; //����������, � ������� ����� ������������� � ������ Start() �������� ������� �������

    private bool _isTimer; //��� ���������� ����� �������� �� �������, ����� ��� ����� ����� �������� ������
    private bool isAnswerCorrectly;
    private bool isAnswerInCorrectly;
 
    private int correctAnswer = 0;
    private int incorrectanswer = 0;

    public int indexLevel;

    private UsingHints usingHints;

    public bool IsAnswerCorrectly { get => isAnswerCorrectly;}
    public bool IsAnswerInCorrectly { get => isAnswerInCorrectly; }
    public bool _IsTimer { get => _isTimer; }

    private bool isClick = false;//����������, ������� ��������� ���� �� ������ ������ ������ ���� ���. ���� ��, �� �� ���������� ������� ������ ��������������

    private void Start()
    {
        WaitTime = timeToWait;
        IndexLevel();

        
        usingHints = GetComponent<UsingHints>();
    }

    private void Update()
    {
        CountClick();
        ActivateTheFiftyFiftyHint();

        if (_isTimer)
        {
            Timer();
        }
        else
        {
            _isTimer = false;
        }

    }

    public void RightAnswerHundler()
    {
        Correctly();
        InCorrectly();    
        Timer();
        _isTimer = true;
        isClick = true;
        Debug.Log("Answer True");
        isAnswerCorrectly = true;
        isAnswerInCorrectly = false;

        counter.CountScore();
        //counterOfCorrectAnswer.Points();

        CounterCorrectAnswer();
        
        
    }

    public void WrongAnserHundler()
    {
        InCorrectly();
        Correctly();
        Timer();
        _isTimer = true;
        isClick = true;
        Debug.Log("Answer False");
        isAnswerInCorrectly = true;
        isAnswerCorrectly = false;
        CounterInCorrectAnswer();
    
        
    }

    private void Correctly()
    {
        TheSecondAnswerButton.GetComponent<Image>().color = Color.green;
        
    }

    private void InCorrectly()
    {
        TheFirstAnswerButton.GetComponent<Image>().color = Color.red;
        ThirdAnswerButton.GetComponent<Image>().color = Color.red;
        TheFourthAnswerButton.GetComponent<Image>().color = Color.red;
        
    }

    private void ActivateTheFiftyFiftyHint()
    {
        if (usingHints.ActivatedTheFiftyFiftyHint)
        {
            ThirdAnswerButton.GetComponent<Image>().color = Color.red;
            TheFourthAnswerButton.GetComponent<Image>().color = Color.red;

            ThirdAnswerButton.enabled = false;
            TheFourthAnswerButton.enabled = false;
        }
    }

    private void Timer()
    {
        WaitTime -= Time.deltaTime;
        if (WaitTime <= 0)
        {
            
            WaitTime = timeToWait;
            GreenOrRedLamp();
            ChangeQuestion();
            _isTimer = false;
            
        }
    }

    public void ChangeQuestion()
    {
        lamp.CountAnswer();
        
        ThisQuestion.SetActive(false);
        NextQuestion.SetActive(true);
    }

    public void CounterCorrectAnswer()
    {
        if (isAnswerCorrectly)
        {
            correctAnswer++;
        }
        else
        {
            isAnswerInCorrectly = true;
        }
  
    }

    public void CounterInCorrectAnswer()
    {
        if (isAnswerInCorrectly)
        {
            incorrectanswer++;
        }
        else
        {
            isAnswerCorrectly = true;
        }

    }
   

    private void CountClick()//�����, ���������� �� ��, ��� ����� �������������� ������ � ������ ������-���� ������
    {
        if (isClick)
        {
            TheFirstAnswerButton.enabled = false;
            TheSecondAnswerButton.enabled = false;
            ThirdAnswerButton.enabled = false;
            TheFourthAnswerButton.enabled = false;
        }

    }
    public void GreenOrRedLamp()
    {
        if (lamp.Answer == 1 && correctAnswer == 1)
        {
            greenLamp.SetActive(true);
        }
        else if (lamp.Answer == 1 && correctAnswer == 0)
        {
            redLamp.SetActive(true);
        }
        
        if (lamp.Answer == 2 && correctAnswer == 1)
        {
            greenLamp.SetActive(true);
        }
        else if(lamp.Answer == 2 && correctAnswer == 0)
        {
            redLamp.SetActive(true);
        }
        
        if (lamp.Answer == 3 && correctAnswer == 1)
        {
            greenLamp.SetActive(true);
        }
        else if(lamp.Answer == 3 && correctAnswer == 0)
        {
            redLamp.SetActive(true);
        }

        if (lamp.Answer == 4 && correctAnswer == 1)
        {
            greenLamp.SetActive(true);
        }
        else if (lamp.Answer == 4 && correctAnswer == 0)
        {
            redLamp.SetActive(true);
        }

        if (lamp.Answer == 5 && correctAnswer == 1)
        {
            greenLamp.SetActive(true);
        }
        else if (lamp.Answer == 5 && correctAnswer == 0)
        {
            redLamp.SetActive(true);
        }

        if (lamp.Answer == 6 && correctAnswer == 1)
        {
            greenLamp.SetActive(true);
        }
        else if (lamp.Answer == 6 && correctAnswer == 0)
        {
            redLamp.SetActive(true);
        }

        if (lamp.Answer == 7 && correctAnswer == 1)
        {
            greenLamp.SetActive(true);
        }
        else if (lamp.Answer == 7 && correctAnswer == 0)
        {
            redLamp.SetActive(true);
        }

        if (lamp.Answer == 8 && correctAnswer == 1)
        {
            greenLamp.SetActive(true);
        }
        else if (lamp.Answer == 8 && correctAnswer == 0)
        {
            redLamp.SetActive(true);
        }

        if (lamp.Answer == 9 && correctAnswer == 1)
        {
            greenLamp.SetActive(true);
        }
        else if (lamp.Answer == 9 && correctAnswer == 0)
        {
            redLamp.SetActive(true);
        }

        if (lamp.Answer == 10 && correctAnswer == 1)
        {
            greenLamp.SetActive(true);
        }
        else if (lamp.Answer == 10 && correctAnswer == 0)
        {
            redLamp.SetActive(true);
            
        }
    }

    private void IndexLevel()
    {
        TransferIndexLevel.transferIndexLevel = SceneManager.GetActiveScene().buildIndex;

        Debug.Log("Get active scine in a level: " + TransferIndexLevel.transferIndexLevel);
    }

    private void OnEnable()
    {
        if (TransferIndexLevel.transferIndexLevel != 0)
        {
            indexLevel = TransferIndexLevel.transferIndexLevel;
        }
    }

    private void OnDestroy()
    {
        TransferIndexLevel.transferIndexLevel = indexLevel;
    }

}
