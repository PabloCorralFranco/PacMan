using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuTransporter : MonoBehaviour
{
    //PUBLIC VARIABLES
    public Transform to;
    public Rigidbody rb;
    //PRIVATE VARIABLES
    private MainMenu menu;
    void Start()
    {
        menu = FindObjectOfType<MainMenu>();   
    }

    private void OnTriggerEnter(Collider other)
    {
        if (menu.direction.Equals(Vector3.forward))
        {
            menu.direction = -Vector3.right;
            rb.rotation =  Quaternion.Euler(0, -90, 0);
        }
        else
        {
            menu.direction = Vector3.forward;
            rb.rotation = Quaternion.Euler(0, 0, 0);
        }
        other.transform.position = to.position;
    }
}
