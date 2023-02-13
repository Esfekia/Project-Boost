using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipDelay : MonoBehaviour
{
    public GameObject spaceShip;

    private void OnTriggerEnter(Collider other)
    {
        spaceShip.SetActive(true);
    }
}
