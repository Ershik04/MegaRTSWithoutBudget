using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rewards : MonoBehaviour
{
    public static int Reward;

    public static void AddReward(int i)
    {
        Reward += i;
        print(Reward);
    }
}
