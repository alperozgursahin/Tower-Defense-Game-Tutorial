using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int startMoney = 400;

    public int startLives = 20;
    public static int Lives;

    void Start()
    {
        Money = startMoney;
        Lives = startLives;
    }


}
