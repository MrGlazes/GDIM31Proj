using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgPickup : PowerupBase
{
    [SerializeField] private int dmg;

    public override void Apply(PlayerController player)
    {
        player.AddDamage(dmg);
        Debug.Log("Added Damage");
        Destroy(gameObject);
    }

}
