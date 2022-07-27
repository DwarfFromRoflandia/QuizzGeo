 using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]//данная строчка означает, что класс ниже мы сможем сохранить в файле
public class Data : MonoBehaviour
{
    public int diamonds;


    public Data (SaveAndLoadData saveAndLoadData)
    {
        diamonds = saveAndLoadData._diamonds;
    }
}
