using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampScript : MonoBehaviour
{
    private int countAnswer = 1;
    public int Answer { get => countAnswer; }

    public void CountAnswer()
    {
        countAnswer++;
    }
}
