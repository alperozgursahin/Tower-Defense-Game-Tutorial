using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    
    public static int Money;
    public int startMoney = 400;

    public int startLives = 20;
    public static int Lives;

    public static int Rounds = 0;

    void Start()
    {
        Money = startMoney;
        Lives = startLives;
    }


}
