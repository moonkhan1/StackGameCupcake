using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CASP.SoundManager
{

    public class SoundManager : MonoBehaviour
    {
        public Sounds[] sounds;
        public static SoundManager Instance;

        private void Awake() {
            if (Instance == null) {
                Instance = this;
            } else {
                Destroy(gameObject);
                return;
            }
            DontDestroyOnLoad(gameObject);
            foreach (var s in sounds)
            {
                s.source = gameObject.AddComponent<AudioSource>();
                s.source.clip = s.Clip;
                s.source.volume = s.Volume;
                s.source.pitch = s.Pitch;
                s.source.loop = s.Loop;
                // s.source.maxDistance = s.MaxDistance;
                // s.source.minDistance = s.MinDistance;
                // s.source.spatialBlend = s.SpatialBlend;
                // s.source.rolloffMode = s.AudioRollOff;
            }
        }

        private void Start() {
            Play("BackgroundMusic");
        }

        public void Play(string name) {
            Sounds s = System.Array.Find(sounds, sound => sound.Name == name);
            if (s == null)
                return;
            // s.source.Play();
            // For completely play all sounds without cutting some last of sounds
            s.source.PlayOneShot(s.Clip);
        }

    }

}
