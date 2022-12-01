using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePickup : PowerupBase
{
    [SerializeField] private int score;

    public override void Apply(PlayerController player)
    {
        player.AddScore(score);
        Debug.Log("Added score");
        Destroy(gameObject);
    }
}
