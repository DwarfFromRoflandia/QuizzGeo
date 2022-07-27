using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;//��� ������������ ��� �� ���������� ������ ���, ����� �� ����� �������� � ������� � ����� ������������ �������
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem //����������� ����� ��� ��� ����� � �������� ������ ������� ��������� ������� ������. �� �� ����� ������ ��������� ������ ����� ������� ���������� � ������� ������ ����� �����������
{
    public static void SaveData(SaveAndLoadData _saveAndLoadData)//������ ����������� ������� ��� ����, ����� �������� � ��� �������� ���������� ������
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
