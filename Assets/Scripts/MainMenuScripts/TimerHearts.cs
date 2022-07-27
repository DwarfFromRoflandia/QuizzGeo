using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

//������ �� ����� � ���, ��� ������� ���� ������: https://www.youtube.com/watch?v=HLz_k6DSQvU

public class TimerHearts : MonoBehaviour
{  
    [SerializeField] private Text timerText;
    [SerializeField] private float startMinutes; //������ ���������� ����� ��������� �������� 
    [SerializeField] private Button btnBigGeoTrip;
    [SerializeField] private GameObject heartsInfoBtn;

    [SerializeField] private Animator animatorFirstHeart;
    [SerializeField] private Animator animatorSecondHeart;
    [SerializeField] private Animator animatorThirdHeart;

    [SerializeField] private Products products;

    private float timeUntilTheFirstHeartRestored = 580;
    private float timeUntilTheSecondHeartRestored = 575; 
    private float timeUntilTheThirdHeartRestored = 570;  


    private HeartsVersionTwo hearts;
    
    public float ontime;

    private bool isTimer  = false;

    public bool IsTimer { get { return isTimer;} set { isTimer = value; } }


    public void StopTimer()
    {
        isTimer = false;
        ontime = startMinutes;
        hearts.PanelTimerHealth.SetActive(false);
    }

    //����� ������ �������
    public void HeartsTimer()
    {
        if (isTimer)
        {
            ontime -= Time.deltaTime;
            if (ontime < 0f)
            {
                isTimer = false;
                ontime = startMinutes;
            }
            RecoveryHearts();

            AnimationRecoveryOfTheFirstHeart();
            AnimationRecoveryOfTheSecondHeart();
            AnimationRecoveryOfTheThirdHeart();


        }
        TimeSpan time = TimeSpan.FromSeconds(ontime); //������ �������� �� ����� �������������� ������� � ������
        timerText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString();//����� ������ ������ �������
    }
    private void Start()
    {
        hearts = GetComponent<HeartsVersionTwo>();
        ontime = startMinutes * 60f; //� ���������� currentTime ����� ������� ������� �������� � ��������                        
    }

    //�����, ������� ��������������� ������
    private void RecoveryHearts()
    {
        //����� ����� ������ ������ ��������, ��������� ������� ����, ����� ������ ������ ��������� �� ����� 30 ���, � ����� ��������� �����

        //    //�������� ����������� � ������� ������� ���¨���� ������� ������ ����� ������ ���������, ���� �� �������������� ��� ��� ��������.

        if (ontime <= timeUntilTheFirstHeartRestored)
        {         
            hearts.NoHearts = false;
            hearts.IsOneHearts = true;

            hearts.QuantityHearts = 1;           
        }
        if (ontime <= timeUntilTheSecondHeartRestored)
        {
            hearts.IsOneHearts = false;
            hearts.IsTwoHearts = true;      

            hearts.QuantityHearts = 2;
        }
        if (ontime <= timeUntilTheThirdHeartRestored)
        {
            hearts.IsTwoHearts = false;
            hearts.IsFullHearts = true;

            hearts.QuantityHearts = 3;  

            StopTimer();
        }
    }

    private void AnimationRecoveryOfTheFirstHeart()
    {
        if (ontime >= timeUntilTheFirstHeartRestored)
        {
            hearts.HeartOneFull.gameObject.SetActive(true);           
        }
        animatorFirstHeart.SetBool("TheRecoveringFirstHeart", hearts.NoHearts == true);

    }

    private void AnimationRecoveryOfTheSecondHeart()
    {
        if (ontime >= timeUntilTheSecondHeartRestored && ontime < timeUntilTheFirstHeartRestored)
        {
            hearts.HeartTwoFull.gameObject.SetActive(true);          
        }
        animatorSecondHeart.SetBool("TheRecoveringSecondHeart", hearts.IsOneHearts == true);
    }

    private void AnimationRecoveryOfTheThirdHeart()
    {
        if (ontime >= timeUntilTheThirdHeartRestored && ontime < timeUntilTheSecondHeartRestored)
        {
            hearts.HeartThreeFull.gameObject.SetActive(true);     
        }
        animatorThirdHeart.SetBool("TheRecoveringThirdHeart", hearts.IsTwoHearts == true);
    }

        
}
