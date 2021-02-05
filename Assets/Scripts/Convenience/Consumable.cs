using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : MonoBehaviour
{
    //PUBLIC VARIABLES
    public AudioSource src;
    public AudioClip clip;
    public LayerMask playerLayer;
    public string consumableName;

    //PRIVATE VARIABLES
    Inventory inv;
    Interface iface;
    void Start()
    {
        inv = FindObjectOfType<Inventory>();
        iface = FindObjectOfType<Interface>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer.Equals(8))
        {
            src.PlayOneShot(clip);
            if (consumableName.Equals("Terrifier"))
            {
                FindObjectOfType<GameMaster>().frightenedState();    
            }
            else
            {
                inv.setCoins(10);
            }
            iface.changeCoinsTxt(inv.getCoins());
            Destroy(this.gameObject);
        }
    }
}
