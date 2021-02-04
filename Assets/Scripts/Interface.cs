using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Interface : MonoBehaviour
{
    public GameObject winningScreen;
    public TextMeshProUGUI coinsText, livesText;

    public void changeCoinsTxt(int coins)
    {
        coinsText.text = coins.ToString();
    }

    public void changeLives(int lives)
    {
        livesText.text = lives.ToString();
    }

    public void winning()
    {
        winningScreen.SetActive(true);
        Time.timeScale = 0;
    }

}
