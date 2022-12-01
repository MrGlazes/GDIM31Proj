using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    
    private static bool isActive = false;
    
    private void Update()
    {
        //Checks if the game scene is in play. If not, and the player isnt spawned we get a swamp of the same error that player doesn't exist.
        if (!isActive)
        {
            return;
        }
        else
        {
            transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        }
        

    }

    //static so can be called without an object being instantiated. 
    public static void Activate()
    {
        isActive = true;
    }
    public static void Deactivate()
    {
        isActive = false;
    }
}

