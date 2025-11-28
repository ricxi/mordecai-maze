using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Audio Clips", menuName = "Scriptable Object/Audio Clips")]
public class AudioClips : ScriptableObject
{
    public AudioClip BellSound;
    public AudioClip LockedDoor;
}
