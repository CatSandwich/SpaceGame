using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;

public class ThrusterAudio : MonoBehaviour
{
    public AudioSource thrusterImpact;
    public AudioSource thrusterAmbient;
    public AudioSource shoot;
    public AudioMixer thrusterMixer;
    bool thrusterOn = false;
    float thrusterVolume = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) {
            SetThrusterOn(true);
        }
        if (Input.GetMouseButtonUp(1)) {
            SetThrusterOn(false);
        }

        // Audio Decay
        if (!thrusterOn) {
            thrusterVolume = Mathf.Max(0, thrusterVolume - Time.deltaTime * 0.5f);
        }

        UpdateThrusterMixer();
    }

    public void PlayShoot()
    {
        shoot.PlayOneShot(shoot.clip);
    }

    public void SetThrusterOn(bool on)
    {
        thrusterOn = on;

        if (on) {
            thrusterImpact.PlayOneShot(thrusterImpact.clip);
            thrusterVolume = 1;
        }
    }

    void UpdateThrusterMixer() {
        float vol = Mathf.Lerp(-40, 0, thrusterVolume);
        thrusterMixer.SetFloat("thrusterVol", vol);
    }
}
