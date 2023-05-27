using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashToOrb : MonoBehaviour
{
    [SerializeField] 
    float dashTime = 0.3f;

    [SerializeField]
    float dashForce = 10f;

    private LockToOrb lockToOrbScript;

    private void Start()
    {
        lockToOrbScript = GetComponent<LockToOrb>();
    }

    private void Update()
    {
        if (lockToOrbScript.lockedTarget != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartCoroutine(DashCoroutine());
            }            
        }
    }

    private IEnumerator DashCoroutine()
    {

        float startTime = Time.time;
        while (Time.time < startTime + dashTime)
        {
            transform.position = Vector3.MoveTowards(transform.position, lockToOrbScript.lockedTarget.position, dashForce * Time.deltaTime);
            yield return null;
        }
    }
}
