using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AnswerScriptBtn : MonoBehaviour
{
    [Header("Кнопки ответов")]
    [SerializeField] private Button TheFirstAnswerButton;//в эту переменную присваиваем первую кнопку ответа
    [SerializeField] private Button TheSecondAnswerButton;//в эту переменную присваиваем вторую кнопку ответа
    [SerializeField] private Button ThirdAnswerButton;//в эту переменную присваиваем третью кнопку ответа
    [SerializeField] private Button TheFourthAnswerButton;//в эту переменную присваиваем четвёртую кнопку ответа

    //[Header("Нынешний и следующий вопрос")]
    //[SerializeField] private GameObject ThisQuestion;//в эту переменную присваиваем вопрос на котором находимся сейчас
    //[SerializeField] private GameObject NextQuestion;//в эту переменную присваиваем следующий вопрос
    [SerializeField] private GameObject ResultPanel;

    [SerializeField] private float timeToWait; //переменная, отвечающая за количество времени таймера

    [Header("Счётчик")]

    [SerializeField] private CounterAnswer counter;
    [SerializeField] private StarsCount starsCount;
    [SerializeField] private CounterOfCorrectAnswer counterOfCorrectAnswer;

    [Header("Лампы")]
    //[SerializeField]private LampScript lamp;
    [SerializeField] private GameObject greenLamp;
    [SerializeField] private GameObject redLamp;


    private float WaitTime; //переменная, в которую будет присваиваться в методе Start() значение времени таймера

    private bool _isTimer; //эта переменная будет отвечать за условие, когда нам нужно будет включать таймер
    private bool isAnswerCorrectly;
    private bool isAnswerInCorrectly;
 
    private int correctAnswer = 0;
    private int incorrectanswer = 0;

    public int indexLevel;

    private UsingHints usingHints;
    public SwitchQuestion switchQuestion;

    public bool IsAnswerCorrectly { get => isAnswerCorrectly;}
    public bool IsAnswerInCorrectly { get => isAnswerInCorrectly; }
    public bool _IsTimer { get => _isTimer; }

    private bool isClick = false;//переменная, которая проверяет была ли нажата кнопка ответа один раз. Если да, то на дальнейшие нажатия кнопок деактивируются

    private int countLamp = 1;//счётчик, который обозначает какую по счёту лампу следует включать

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
        //Timer();
        _isTimer = true;
        isClick = true;
        Debug.Log("Answer True");
        isAnswerCorrectly = true;
        isAnswerInCorrectly = false;

        counter.CountScore();

        CounterCorrectAnswer();     
    }

    public void WrongAnserHundler()
    {
        InCorrectly();
        Correctly();
        //Timer();
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
            Debug.Log("STOP THIS TIMER");
            GreenOrRedLamp();
            ChangeQuestion();
            _isTimer = false;
            switchQuestion.countQuestion++;
        }
    }

    public void ChangeQuestion()
    {
        countLamp++;


        //ThisQuestion.SetActive(false);
        //NextQuestion.SetActive(true);
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
   
    private void CountClick()//метод, отвечающий за то, что когда деактивировать кнопки в случае какого-либо ответа
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
        if (countLamp == 1 && correctAnswer == 1)
        {
            greenLamp.SetActive(true);
        }
        else if (countLamp == 1 && correctAnswer == 0)
        {
            redLamp.SetActive(true);
        }
        
        if (countLamp == 2 && correctAnswer == 1)
        {
            greenLamp.SetActive(true);
        }
        else if(countLamp == 2 && correctAnswer == 0)
        {
            redLamp.SetActive(true);
        }
        
        if (countLamp == 3 && correctAnswer == 1)
        {
            greenLamp.SetActive(true);
        }
        else if(countLamp == 3 && correctAnswer == 0)
        {
            redLamp.SetActive(true);
        }

        if (countLamp == 4 && correctAnswer == 1)
        {
            greenLamp.SetActive(true);
        }
        else if (countLamp == 4 && correctAnswer == 0)
        {
            redLamp.SetActive(true);
        }

        if (countLamp == 5 && correctAnswer == 1)
        {
            greenLamp.SetActive(true);
        }
        {
            redLamp.SetActive(true);
        }

        if (countLamp == 6 && correctAnswer == 1)
        {
            greenLamp.SetActive(true);
        }
        else if (countLamp == 6 && correctAnswer == 0)
        {
            redLamp.SetActive(true);
        }

        if (countLamp == 7 && correctAnswer == 1)
        {
            greenLamp.SetActive(true);
        }
        else if (countLamp == 7 && correctAnswer == 0)
        {
            redLamp.SetActive(true);
        }

        if (countLamp == 8 && correctAnswer == 1)
        {
            greenLamp.SetActive(true);
        }
        else if (countLamp == 8 && correctAnswer == 0)
        {
            redLamp.SetActive(true);
        }

        if (countLamp == 9 && correctAnswer == 1)
        {
            greenLamp.SetActive(true);
        }
        else if (countLamp == 9 && correctAnswer == 0)
        {
            redLamp.SetActive(true);
        }

        if (countLamp == 10 && correctAnswer == 1)
        {
            greenLamp.SetActive(true);
        }
        else if (countLamp == 10 && correctAnswer == 0)
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
