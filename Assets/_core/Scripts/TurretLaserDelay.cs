using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretLaserDelay : MonoBehaviour
{
    public ParticleSystem laser;

    private void OnTriggerEnter(Collider other)
    {        
        {
            Debug.Log("Commencing Repeater..");
            RepeatEvery5Seconds();
        }
    }
    void RepeatEvery5Seconds()
    {
        Debug.Log("Repeated Engaged..");
        InvokeRepeating("FireLaser", 0, 20);
    }
    void FireLaser()
        {
        Debug.Log("Firing Laser..");
        // Fire Laser
            laser.Play();
        }
}
    
