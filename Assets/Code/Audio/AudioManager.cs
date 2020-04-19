using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioPlayer DrawPlayer;

    public void PlayDraw(float delay)
    {
        DrawPlayer.Play(delay);
    }
}
