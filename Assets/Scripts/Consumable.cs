using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : MonoBehaviour
{
    public LayerMask playerLayer;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer.Equals(8))
        {
            Inventory inv = FindObjectOfType<Inventory>();
            inv.setCoins(1);
            Destroy(this.gameObject);
        }
    }
}
