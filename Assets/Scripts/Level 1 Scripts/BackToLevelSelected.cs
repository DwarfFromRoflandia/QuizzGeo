using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class BackToLevelSelected : MonoBehaviour
{
    //ниже две пермеенные мы можем использовать дл€ того, чтобы разблокировать следующий уровень при прохождении предыдущего. ћы моэем использовать две переменные: int или string в медоде LevelEnd, где используетс€ PlayerPrefs. Int обозначает индекс следующей сцены, которую нужно раблокировать, а string название той сцены, которую нужно разблокировать. »спользовать можно что-то одно
    public string nextLevel = "Level2";
    public int levelToUnlock = 1;

    private void Start()
    {
        levelToUnlock++;
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);

        LevelEnd();

        Debug.Log(" оличесвто звЄзд в меню выбора уровней: " + TransferStars.transferStras);
    }

    private void LevelEnd()
    {
        
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
    }


}
