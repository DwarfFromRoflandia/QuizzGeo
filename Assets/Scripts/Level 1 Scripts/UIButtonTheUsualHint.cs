using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonTheUsualHint : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private HintButtons hintButtons;
    [SerializeField] private UsingUsualHint usingUsualHint;
    [SerializeField] private TimerRing timerRing;

    private bool clampedButton;//булевская переменная, которая отвечает за то, зажата ли кнопка подсказки или нет
    public bool ClampedButton { get { return clampedButton; } set { clampedButton = value; } }

    private int clickButton = 0;//счётчик того, сколько раз игрок нажал на кнопку подсказки

    private bool lastUsualHintUsed;//булевская переменная, которая отвечает за то событие, когда игрок заюзал последнюю подсказку

    private void Update()
    {
        IsLastUsualHintUsed();
    }

    private void Start()
    {
        InteractableTheUsualHint();
        clampedButton = false;
        lastUsualHintUsed = false;       
    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        if (TransferTheUsualHint.transferQuantityTheUsualHint > 0)
        {
            clampedButton = true;
            clickButton++;
            UsingUsualHint();

            CanTheHintBeEnabled();
        }
        else if (TransferTheUsualHint.transferQuantityTheUsualHint == 0 && clickButton == 1)
        {
            clampedButton = true;

            CanTheHintBeEnabled();
        }
        
    }
    public void OnPointerUp(PointerEventData pointerEventData)
    {
        clampedButton = false;
        usingUsualHint.NoActivateUsualHint();
    }

    private void UsingUsualHint()
    {
        if (clampedButton == true && clickButton == 1 && timerRing.IsTimer == true && TransferTheUsualHint.transferQuantityTheUsualHint != 0)
            TransferTheUsualHint.transferQuantityTheUsualHint -= 1;
    }

    private void InteractableTheUsualHint()
    {
        if (TransferTheUsualHint.transferQuantityTheUsualHint > 0)
            hintButtons.EnabledTheUsualHint();
        else if (lastUsualHintUsed && TransferTheUsualHint.transferQuantityTheUsualHint == 0)
            hintButtons.EnabledTheUsualHint();           
        else
            hintButtons.UnavailableTheUsualHint();
    }

    private void IsLastUsualHintUsed()
    {
        if (TransferTheUsualHint.transferQuantityTheUsualHint == 0 && clickButton == 1)
            lastUsualHintUsed = true;
        else
            lastUsualHintUsed = false;
    }

    private void CanTheHintBeEnabled()
    {
        if (timerRing.IsTimer == true && clampedButton == true)
            usingUsualHint.ActivateUsualHint();
        else
            clampedButton = false;
    }
}
