using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsCount : MonoBehaviour
{
    
    [SerializeField] private CounterAnswer scoreCount;

    [Header("¬ключЄнные звЄзды")]
    [SerializeField] private GameObject star1On;
    [SerializeField] private GameObject star2On;
    [SerializeField] private GameObject star3On;

    private int countStar;
    public int CountStars { get => countStar; }

    private void Start()
    {
        CountStar();
    }

    public void CountStar()
    {
        if (scoreCount.Score >= 3 && scoreCount.Score < 6)
        {
            star1On.SetActive(true);

            countStar += 3;

            
        }
        if (scoreCount.Score >= 6 && scoreCount.Score < 9)
        {
            star1On.SetActive(true);
            star2On.SetActive(true);

            countStar += 6;

        }
        if (scoreCount.Score >= 9)
        {
            star1On.SetActive(true);
            star2On.SetActive(true);
            star3On.SetActive(true);

            countStar += 9;

        }   
    }


    private void OnEnable()
    {
        if (TransferStars.transferStras != 0)
        {
            countStar = TransferStars.transferStras;
        }
    }

    private void OnDestroy()
    {
        TransferStars.transferStras = countStar;
    }



}
