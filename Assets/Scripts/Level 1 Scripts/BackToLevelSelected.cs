using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class BackToLevelSelected : MonoBehaviour
{
    public int levelToUnlock;//переменная, которая будет использоваться для того, чтобы разблокировать следующий уровень

    private void Update()
    {
        TransferValueLevelToUnlock.valueLevelToUnlock = levelToUnlock;
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
        Debug.Log("Количесвто звёзд в меню выбора уровней: " + TransferStars.transferStras);
        levelToUnlock++;//делаем инкремент данной переменной для того, чтобы когда игрок зайдёт в меню выбора уровня, ему был доступен следующий уровень
    }

    private void OnEnable()
    {
        if (TransferValueLevelToUnlock.valueLevelToUnlock != 0)
        {
            levelToUnlock = TransferValueLevelToUnlock.valueLevelToUnlock;
        }
    }
    private void OnDestroy()
    {
        TransferValueLevelToUnlock.valueLevelToUnlock = levelToUnlock;
    }
}
