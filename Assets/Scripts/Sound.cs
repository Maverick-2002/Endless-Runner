using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public SoundEnum soundName;  // Changed from string name to SoundEnum soundName
    public AudioClip sound;
}
public enum SoundEnum
{
    SoundTrack,
    Coin,
    Fuel,
    Fall
}