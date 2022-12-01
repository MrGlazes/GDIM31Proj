using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : PowerupBase
{
    [SerializeField] private int health;

    public override void Apply(PlayerController player)
    {
        player.AddHealth(health);
        Debug.Log("Added Health");
        Destroy(gameObject);
    }
}
