using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CASP.SoundManager
{

    [System.Serializable]
    public class Sounds
    {
        public string Name;
        public AudioClip Clip;
        [Range(0,1)]
        public float Volume;
        [Range(0.1f,3f)]
        public float Pitch;
        public bool Loop;
        // public int MaxDistance;
        // public int MinDistance;
        // [Range(0.1f, 1f)]
        // public float SpatialBlend;
        // public AudioRolloffMode AudioRollOff;


        [HideInInspector]
        public AudioSource source;
    }

}