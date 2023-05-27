using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the player entered orb collider
        if (other.tag == "Player")
        {
            // Destroy the orb after collision
            Destroy(gameObject);
        }
    }
}
