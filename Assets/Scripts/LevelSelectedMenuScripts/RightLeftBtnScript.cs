using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightLeftBtnScript : MonoBehaviour
{
    [SerializeField] private GameObject FirstMenuLevelSelected;
    [SerializeField] private GameObject SecondMenuLevelSelected;
    [SerializeField] private GameObject InfoPanel;
    public void RightBtnHundler()
    {
        FirstMenuLevelSelected.SetActive(false);
        SecondMenuLevelSelected.SetActive(true);
        InfoPanel.SetActive(false);
    }

    public void LeftBtnHundler()
    {
        SecondMenuLevelSelected.SetActive(false);
        FirstMenuLevelSelected.SetActive(true);
    }
}
