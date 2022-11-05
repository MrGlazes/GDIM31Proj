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
        if (!isActive)
        {
            return;
        }
        else
        {
            transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        }
        

    }

    public static void Activate()
    {
        isActive = true;
    }
    public static void Deactivate()
    {
        isActive = false;
    }
}

