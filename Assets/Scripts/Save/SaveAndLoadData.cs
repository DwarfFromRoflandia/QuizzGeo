using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAndLoadData : MonoBehaviour
{
    public int _diamonds = TransferGem.transferGems;

    public void Save()
    {
        SaveSystem.SaveData(this);
    }

    public void Load()
    {
        Data data = SaveSystem.LoadData();
        _diamonds = data.diamonds;
    }
}
