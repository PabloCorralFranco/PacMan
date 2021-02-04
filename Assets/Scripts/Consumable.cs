using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : MonoBehaviour
{
    public LayerMask playerLayer;
    public string consumableName;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer.Equals(8))
        {
            if (consumableName.Equals("Terrifier"))
            {
                FindObjectOfType<GameMaster>().frightenedState();
                Destroy(this.gameObject);
            }
            else
            {
                Inventory inv = FindObjectOfType<Inventory>();
                inv.setCoins(10);
                FindObjectOfType<Interface>().changeCoinsTxt(inv.getCoins());
                Destroy(this.gameObject);
            }
        }
    }
}
