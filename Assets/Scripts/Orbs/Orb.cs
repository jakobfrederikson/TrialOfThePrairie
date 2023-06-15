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
        public OrbType OrbType { get; set; }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
                Destroy(this.gameObject);
        }

        public void GiveReward()
        {
            switch (OrbType)
            {
                case OrbType.Sprint:
                    firstPersonController.sprintOrbUnlocked = true;
                    break;
                case OrbType.DoubleJump:
                    firstPersonController.doubleJumpOrbUnlocked = true;
                    break;
                case OrbType.Glide:
                    firstPersonController.glideOrbUnlocked = true;
                    break;
                case OrbType.LockOn:
                    firstPersonController.lockOnOrbUnlocked = true;
                    break;
                default:
                    // do nothing
                    break;
            }
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
