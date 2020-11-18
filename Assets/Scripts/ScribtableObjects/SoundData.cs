using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SoundData", menuName = "SoundData", order = 51)]
public class SoundData : ScriptableObject
{
    [SerializeField]
    public AudioClip[] audioClips;
    
}
