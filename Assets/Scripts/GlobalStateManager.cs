using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalStateManager : MonoBehaviour {

    public static int[] expOrder = new int[100];  // 爆発の順番を格納しておく
    public static int i = 0;
    public static int expNum = 0;

    public void PlayerDied(int playerNumber)
    {

    }

    public static void EnOrder(int playerNum)
    {
        if (i < expOrder.Length)
        {
            if (playerNum == 1 || playerNum == 2)
            {
                expOrder[i] = playerNum;
                i++;
            }

        }
        else
        {
            Debug.Log("EnOrder,Error!!");
        }

    }

    public static void DeOrder()
    {
        if (expOrder[0] != 1 || expOrder[0] != 2)
        {
            expNum = expOrder[0];
            for (int k = 1; k <= i; k++)
            {
                expOrder[k - 1] = expOrder[k];
            }
            i--;
        }
        else
        {
            Debug.Log("DeOrder,Error!!");
        }
    }

}
