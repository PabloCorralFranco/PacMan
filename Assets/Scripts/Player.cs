using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //PUBLIC VARIABLES
    public float speed;

    //PRIVATE VARIABLES
    private Rigidbody rb;
    private Animator anim;
    private Vector3 moveDirection;
    private float horizontal, vertical, lookAtAngle;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        InputCollection();
    }

    void FixedUpdate()
    {
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;
        anim.SetFloat("Speed", direction.magnitude);
        if (direction.magnitude > 0.1f)
        {
            lookAtAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            moveDirection = Quaternion.Euler(0f, lookAtAngle, 0f) * Vector3.forward;
            rb.rotation = Quaternion.Euler(0f, lookAtAngle, 0f);
            rb.AddForce(moveDirection * speed);
        }
    }

    private void InputCollection()
    {
        if(vertical == 0) horizontal = Input.GetAxis("Horizontal");
        if(horizontal == 0) vertical = Input.GetAxis("Vertical");
    }
}
