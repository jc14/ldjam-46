using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioPlayer DrawPlayer;
    [SerializeField] private AudioPlayer PlacePlayer;
    [SerializeField] private AudioPlayer DiscardPlayer;
    [SerializeField] private AudioPlayer SelectPlayer;
    [SerializeField] private AudioPlayer DeselectPlayer;

    public void PlayDraw(float delay)
    {
        DrawPlayer.Play(delay);
    }

    public void PlayPlacePlayer()
    {
        PlacePlayer.Play();
    }

    public void PlayDiscardPlayer()
    {
        DiscardPlayer.Play();
    }

    public void PlaySelectPlayer()
    {
        SelectPlayer.Play();
    }

    public void PlayDeselectPlayer()
    {
        DeselectPlayer.Play();
    }
}
