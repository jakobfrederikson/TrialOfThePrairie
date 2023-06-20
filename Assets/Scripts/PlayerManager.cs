// this will be converted to the holy grail

using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;
    public FirstPersonController firstPersonController;
    public int CollectibleBalance { get; set; }
    public float Speed { get; set; }
    public float Gravity { get; set; }
    public float GlideSpeed { get; set; }
    public float SprintSpeed { get; set; }

    public bool LockOnOrbUnlocked { get; set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }        
    }

    private void Start()
    {
        CollectibleBalance = 0;
        Speed = firstPersonController.MoveSpeed;
        Gravity = firstPersonController.Gravity;
        GlideSpeed = firstPersonController.GlideSpeed;
        SprintSpeed = firstPersonController.SprintSpeed;
    }
}
