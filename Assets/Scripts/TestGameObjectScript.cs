using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGameObjectScript : MonoBehaviour
{
    private GameObject testGameObject;
    private SecondTestGameObject secondTestGameObject;

    
    private int amountOfMoney = 20;
    private int cost = 5;

    private void Start()
    {
        testGameObject = GameObject.FindGameObjectWithTag("SecondTestGameObject");
        secondTestGameObject = GameObject.FindGameObjectWithTag("SecondTestGameObject").GetComponent<SecondTestGameObject>();
        cost = BuyProduct(cost);
        Debug.Log(cost);
    }

    private int BuyProduct(int prise) => amountOfMoney -= prise;
   

}
