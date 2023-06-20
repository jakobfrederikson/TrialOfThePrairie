using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    // TO DO:
    // On player enter, destroy this
    // Increase total collectible count by 1
    // Increase speed + lower gravity for 2 seconds
    // update on screen

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CollectibleManager.Instance.AcquiredCollectible();
            Destroy(this.gameObject);            
        }            
    }
}
