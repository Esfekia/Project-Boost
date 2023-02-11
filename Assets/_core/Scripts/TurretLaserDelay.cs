using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretLaserDelay : MonoBehaviour
{
    public ParticleSystem laser;
    public AudioSource laserChargeSound;
    public AudioSource laserFireSound;

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
            PlayLaserCharge();
        }

    void PlayLaserCharge()
    {
        laserChargeSound.volume = 0.2f;
        laserChargeSound.Play();
        Invoke("StopLaserChargeAfter5Seconds", 5);
    }

    void PlayLaserFire()
    {
        laserFireSound.Play();
        Invoke("StopLaserFireAfter5Seconds", 3);
    }    

    void StopLaserChargeAfter5Seconds()
    {
        laserChargeSound.Stop();
        PlayLaserFire();
        
    }

    void StopLaserFireAfter5Seconds()
    {
        laserFireSound.Stop();
    }
}
    
