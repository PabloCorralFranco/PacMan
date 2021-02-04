using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transporter : MonoBehaviour
{
    public Transform to;

    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = to.position;
    }
}
