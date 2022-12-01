using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerupBase : MonoBehaviour
{
    [SerializeField] private PickupController pickupPrefab;

    public void Start()
    {
        PickupController instance = Instantiate(pickupPrefab, transform);
        instance.Init(this);
    }

    public abstract void Apply(PlayerController player);
}
