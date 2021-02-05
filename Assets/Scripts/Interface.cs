using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interface : MonoBehaviour
{
    public GameObject winningScreen;
    public TextMeshProUGUI coinsText, livesText;
    private bool win;

    void Start()
    {
        win = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene("MainMenu");
    }

    void FixedUpdate()
    {
        if (win)
        {
            if (Input.GetKeyDown(KeyCode.M)) SceneManager.LoadScene("MainMenu"); 
            if (Input.GetKeyDown(KeyCode.R)) SceneManager.LoadScene("SampleScene"); 
        }
    }

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
        win = true;
    }

}
