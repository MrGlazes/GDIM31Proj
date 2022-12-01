using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPowerup : MonoBehaviour
{
    [SerializeField] List<PowerupBase> powerPrefabs = new List<PowerupBase>();

    private void Start()
    {
        int randomInd = Random.Range(0, powerPrefabs.Count);
        Instantiate(powerPrefabs[randomInd], transform);
    }
}
