using StarterAssets;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Orb : MonoBehaviour
    {
        [SerializeField] internal FirstPersonController firstPersonController;
        [SerializeField] public TextMeshProUGUI orbDestroyText;
        //[SerializeField] public Animator animator;

        private void Start()
        {
            orbDestroyText.enabled = false;
        }

        private void OnDestroy()
        {
            //animator.SetBool("IsVisible", true);
        }
    }
}
