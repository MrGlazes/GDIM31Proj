using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")    //Similar to floopy burd, except trigger is player
        {
            Destroy(gameObject);
        }
    }
}
