using StarterAssets;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Orb : MonoBehaviour
    {
        [SerializeField] internal FirstPersonController firstPersonController;

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
                Destroy(this.gameObject);
        }
    }
}
