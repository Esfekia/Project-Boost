using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunshot : MonoBehaviour
{
    public AudioSource gunshotSound;
    public AudioClip gunshotClip;
    public ParticleSystem bullets;

    public void PlayGunShot()
    {
        gunshotSound.PlayOneShot(gunshotClip);
        // Play particle effect for 1 second and then stop it
        PlayParticleSystemFor1Second();
    }
        
    public void PlayParticleSystemFor1Second()
    {
        bullets.Play();
        StartCoroutine(StopParticleSystem());
    }
    
    IEnumerator StopParticleSystem()
    {
        yield return new WaitForSeconds(1);
        bullets.Stop();
    }
}
