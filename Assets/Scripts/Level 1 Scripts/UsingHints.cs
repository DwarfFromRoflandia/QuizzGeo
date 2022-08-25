using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UsingHints : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _QuantityTheUsualHintText;
    [SerializeField] private TextMeshProUGUI _QuantityTheFiftyFiftyHintText;

    [SerializeField] private Button _TheUsualHintButton;
    [SerializeField] private Button _TheFiftyFiftyHintButton;

    private TimerRing _timerRing;
    
    private bool activatedTheFiftyFiftyHint = false;
    public bool ActivatedTheFiftyFiftyHint { get => activatedTheFiftyFiftyHint; }

    private void Start()
    {
        _timerRing = GetComponent<TimerRing>();
    }
    private void Update()
    {
        UsingTheFiftyFiftyHintIsAvailable();
    }    

    private void LateUpdate()//используем здесь LateUpdate для того, чтобы при обновлении вопроса числа количества подсказок не мерцали
    {
        AssignQuantityTheFiftyFiftyHint();
        AssignQuantityTheUsualHint();
    }

    public void UsingTheFiftyFiftyHint()
    {      
        if (_timerRing.IsTimer == true)
        {
            Debug.Log("UsingTheFiftyFiftyHint");
            TransferTheFiftyFiftyHint.transferQuantityTheFiftyFiftyHint -= 1;
            activatedTheFiftyFiftyHint = true;
        }
    }

    private void AssignQuantityTheUsualHint()
    {
        _QuantityTheUsualHintText.text = TransferTheUsualHint.transferQuantityTheUsualHint.ToString();
    }

    private void AssignQuantityTheFiftyFiftyHint()
    {
        _QuantityTheFiftyFiftyHintText.text = TransferTheFiftyFiftyHint.transferQuantityTheFiftyFiftyHint.ToString();
    }

    private void UsingTheFiftyFiftyHintIsAvailable()
    {
        if (TransferTheFiftyFiftyHint.transferQuantityTheFiftyFiftyHint <= 0)
        {
            _TheFiftyFiftyHintButton.interactable = false;
        }
        else if (activatedTheFiftyFiftyHint)
        {
            _TheFiftyFiftyHintButton.enabled = false;
        }
    }

}
