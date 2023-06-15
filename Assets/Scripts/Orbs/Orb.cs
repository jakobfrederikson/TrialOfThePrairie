using StarterAssets;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Orb : MonoBehaviour
    {
        [SerializeField] internal FirstPersonController firstPersonController;

        // the name of the child orb to display once acquired
        public abstract string Name { get; }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
                Destroy(this.gameObject);
        }
    }
}
