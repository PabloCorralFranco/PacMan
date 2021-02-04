using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private int coins, totalCoins;

    //GETTERS AND SETTERS
    public void setCoins(int cuantity)
    {
        setPoints(cuantity);
        totalCoins += 1;
    }

    public int getCoins()
    {
        return coins;
    }

    public void setPoints(int cuantity)
    {
        coins += cuantity;
    }

    public int getTotalCoins()
    {
        return totalCoins;
    }


}
