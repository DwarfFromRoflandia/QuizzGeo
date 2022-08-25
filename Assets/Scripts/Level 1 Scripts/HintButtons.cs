using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintButtons : MonoBehaviour
{
    public Button[] buttonsTheUsualHint;
    public Button[] buttonsTheFiftyFiftyHint;

    void Update()
    {
        InteractableTheFiftyFiftyHint();  
    }

    public void EnabledTheUsualHint()
    {
        for (int i = 0; i < buttonsTheUsualHint.Length; i++)
        {
            buttonsTheUsualHint[i].interactable = true;
        }
    }

    public void UnavailableTheUsualHint()
    {
        for (int i = 0; i < buttonsTheUsualHint.Length; i++)
        {
            buttonsTheUsualHint[i].interactable = false;
        }
    }

    private void InteractableTheFiftyFiftyHint()
    {
        if (TransferTheFiftyFiftyHint.transferQuantityTheFiftyFiftyHint > 0)
        {
            for (int i = 0; i < buttonsTheFiftyFiftyHint.Length; i++)
            {
                buttonsTheFiftyFiftyHint[i].interactable = true;
            }
        }
        else
        {
            for (int i = 0; i < buttonsTheFiftyFiftyHint.Length; i++)
            {
                buttonsTheFiftyFiftyHint[i].interactable = false;
            }
        }
    }
}
