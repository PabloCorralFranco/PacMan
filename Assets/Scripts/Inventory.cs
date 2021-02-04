using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int coins;

    //GETTERS AND SETTERS
    public void setCoins(int cuantity)
    {
        coins += cuantity;
    }

    public int getCoins()
    {
        return coins;
    }

}
