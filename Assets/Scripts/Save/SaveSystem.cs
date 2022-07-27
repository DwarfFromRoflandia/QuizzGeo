using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;//это пространство имЄн мы используем вс€кий раз, когда мы хотим работать с файлами в нашей операционной системе
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem //статические класс это тот класс у которого нельз€ создать экземпл€р данного класса. ћы не хотим делать несколько версий нашей системы сохранени€ и поэтому делаем класс статическим
{
    public static void SaveData(SaveAndLoadData _saveAndLoadData)//создаЄм статическую функцию дл€ того, чтобы вызывать еЄ без создани€ экземпл€ра класса
    {
        BinaryFormatter formatter = new BinaryFormatter();
        
        string path = Application.persistentDataPath + "/saveAndLoadData.sun";
        FileStream stream = new FileStream(path, FileMode.Create);
        
        Data data = new Data(_saveAndLoadData);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static Data LoadData()
    {
        string path = Application.persistentDataPath + "/saveAndLoadData.sun";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            Data data = formatter.Deserialize(stream) as Data;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in" + path);
            return null;
        }
    }
}
