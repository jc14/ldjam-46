using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDebugger : MonoBehaviour
{
    public AudioSource source;
    public AudioClip[] audioClips;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            source.PlayOneShot(audioClips[0]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            source.PlayOneShot(audioClips[1]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            source.PlayOneShot(audioClips[2]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            source.PlayOneShot(audioClips[3]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            source.PlayOneShot(audioClips[4]);
        }
    }
}
