using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[System.Serializable]//������ ������� ��������, ��� ����� ���� �� ������ ��������� � �����
public class Data
{
    //�������� ������ ��� �������� ������������ ������ https://www.youtube.com/watch?v=3edD7Z2wmsw � https://docs.microsoft.com/ru-ru/dotnet/csharp/programming-guide/classes-and-structs/constructors
    //������ ������ ����� ������������ �� ���� ������ ������ � ������� ����� ��������� ���� ������, ������� �� ������� ���������.
    public int diamonds;
    public int quantityTheUsualHint;
    public int quantityTheFiftyFiftyHint;
    
    public int quantityHearts;
    public float timerHearts;
    public bool isTimer;
    public bool isFullHearts;
    public bool isTwoHearts;
    public bool isOneHearts;
    public bool noHearts;

    public int levelIndex;
    public int transferSrarsInBank;

    public int starsForFirstLevelInBank;
    public int starsForSecondLevelInBank;
    public int starsForThirdLevelInBank;
    public int starsForFourthLevelInBank;
    public int starsForFifthLevelInBank;

    public int achievedLevel;
    public int levelToUnlock;

    public bool isOpenInfoPanel;
    public bool isOpenCreamPanel;

    public bool isLoadGameData;

    //���� �� ������ ����������� ��� ������ ������
    public Data (SaveAndLoadData saveAndLoadData) 
    {
        diamonds = saveAndLoadData._diamonds;//���� �������� ���������� ������� �� ������� saveAndLoadData � ����������� ��� ��������� � ��������� ����������
        quantityTheUsualHint = saveAndLoadData._quantityTheUsualHint;
        quantityTheFiftyFiftyHint = saveAndLoadData._quantityTheFiftyFiftyHint;
        quantityHearts = saveAndLoadData._quantityHearts;
        
        timerHearts = saveAndLoadData._timerHearts;
        isTimer = saveAndLoadData._isTimer;
        isFullHearts = saveAndLoadData._isFullHearts;
        isTwoHearts = saveAndLoadData._isTwoHearts;
        isOneHearts = saveAndLoadData._isOneHearts;
        noHearts = saveAndLoadData._noHearts;   

        levelIndex = saveAndLoadData._levelIndex;
        transferSrarsInBank = saveAndLoadData._transferSrarsInBank;

        starsForFirstLevelInBank = saveAndLoadData._starsForFirstLevelInBank;
        starsForSecondLevelInBank = saveAndLoadData._starsForSecondLevelInBank;
        starsForThirdLevelInBank = saveAndLoadData._starsForThirdLevelInBank;
        starsForFourthLevelInBank = saveAndLoadData._starsForFourthLevelInBank;
        starsForFifthLevelInBank = saveAndLoadData._starsForFifthLevelInBank;

        achievedLevel = saveAndLoadData._achievedLevel;
        levelToUnlock = saveAndLoadData._levelToUnlock;

        isOpenInfoPanel = saveAndLoadData._isOpenInfoPanel;
        isOpenCreamPanel = saveAndLoadData._isOpenCreamPanel;

        isLoadGameData = saveAndLoadData._isLoadGameData;
    }
}
