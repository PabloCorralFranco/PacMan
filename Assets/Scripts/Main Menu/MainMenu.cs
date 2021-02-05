using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //PUBLIC VARIABLES
    public Rigidbody chestRb;
    public Vector3 direction;
    void Start()
    {
        direction = Vector3.forward;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) SceneManager.LoadScene("SampleScene");
    }

    void FixedUpdate()
    {
        chestRb.AddForce(direction * 32);
    }

}
