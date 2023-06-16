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
        public abstract string ID { get; set; }
        public abstract OrbType OrbType { get; set; }        

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
                Destroy(this.gameObject);
        }
    }

    public enum OrbType
    {
        Sprint,
        DoubleJump,
        Glide,
        LockOn
    }
}
