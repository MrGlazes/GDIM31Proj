using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    private PowerupBase powerup;

    public void Init(PowerupBase power)
    {
        powerup = power;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if(player != null)    //Similar to floopy burd, except trigger is player
        {
            powerup.Apply(player);
            Destroy(gameObject);
        }
    }
}
