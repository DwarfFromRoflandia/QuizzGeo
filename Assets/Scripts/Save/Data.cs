 using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]//������ ������� ��������, ��� ����� ���� �� ������ ��������� � �����
public class Data : MonoBehaviour
{
    public int diamonds;


    public Data (SaveAndLoadData saveAndLoadData)
    {
        diamonds = saveAndLoadData._diamonds;
    }
}
