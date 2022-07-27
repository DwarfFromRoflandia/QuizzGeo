using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//ролик, который помог разобраться, как сделать систему постепенного открытия уровней: https://www.youtube.com/watch?v=AQpDtrNJAEU&t=1130s

public class LockLevel : MonoBehaviour
{
    public Button[] LevelButtons;
    public GameObject[] Locks;
    public GameObject[] LevelText;

   // public Button[] UnavailableLevels;//************УДАЛИТЬ ЭТОТ МАССИВ ТОГДА,КОГДА НУЖНО БУДЕТ ЗАПОЛНЯТЬ ВТОРУЮ И ТРЕТЬЮ ПАНЕЛЬ УРОВНЯМИ И ЗАМЕНИТЬ ЗАМОЧКИ НА ТЕКСТ С НОМЕРОМ УРОВНЯ НА СПРАЙТЕ САМОГО УРОВНЯ************////

    private bool levellock;

    private void Start()
    {
        //пересенная ниже будет содержать значение самого последнего уровня в нашей игре
        int levelReached = PlayerPrefs.GetInt("levelReached", 1); //мы хотим, чтобы наш достигнутый уровень по умолчанию был равен единице. Мы делаем это так, что если мы никогда раньше не играли в игру, и она попытается найти сохраненный фрагмент данных с именем level reached, и он еще не создан, она просто вернет значение 1, и поэтому это позволит нам играть только на первом уровне, это будет происходить каждый раз, когда новый игрок играет в игру

        for (int i = 0; i < LevelButtons.Length; i++)
        {
            //если у этой текущей кнопки(кнопки уровня) есть индекс уровня, которого мы еще не достигли, мы хотим сделать эту кнопку неинтерактивной
            if (i + 1 > levelReached)//но, конечно, наш индекс начинается с нуля, и, очевидно, наш достигнутый уровень начинается с единицы, поэтому мы должны просто добавить единицу в индекс, чтобы сделать это полностью действительным
            {
                LevelButtons[i].interactable = false;
                
            }
            if (i + 1 < levelReached)//условие, благодаря которому блокируются кнопки уровней, которые прошёл игрок
            {
                LevelButtons[i].enabled = false;
            }

        }

        for (int i = 0; i < Locks.Length; i++)
        {
            Locks[i].SetActive(true);

            if (LevelButtons[i + 1].interactable == true)
            {
                Locks[i].SetActive(false);
            }
        }


        for (int i = 0; i < LevelText.Length; i++)
        {
            LevelText[i].SetActive(false);

            if (LevelButtons[i + 1].interactable == true)
            {
                LevelText[i].SetActive(true);
            }
        }

        //for (int i = 0; i < UnavailableLevels.Length; i++)//************УДАЛИТЬ ЭТОТ ЦИКЛ ТОГДА,КОГДА НУЖНО БУДЕТ ЗАПОЛНЯТЬ ВТОРУЮ И ТРЕТЬЮ ПАНЕЛЬ УРОВНЯМИ И ЗАМЕНИТЬ ЗАМОЧКИ НА ТЕКСТ С НОМЕРОМ УРОВНЯ НА СПРАЙТЕ САМОГО УРОВНЯ ************//
        //{
        //    UnavailableLevels[i].interactable = false;
        //}

    }


    public void ResetBtn()
    {
        PlayerPrefs.DeleteAll();
    }

}
