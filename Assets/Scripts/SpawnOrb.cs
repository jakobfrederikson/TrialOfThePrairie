using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOrb : MonoBehaviour
{
    [SerializeField] private GameObject _orb;
    private Ray ray;
    private RaycastHit hit;
    private float raycastDistance = 10f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
            if (Physics.Raycast(ray, out hit, raycastDistance))
                _orb.transform.position = hit.point;
            else
                _orb.transform.position = transform.position + ray.direction * raycastDistance;
            Instantiate(_orb);
        }
    }
}
