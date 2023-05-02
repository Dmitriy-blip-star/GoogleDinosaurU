using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.MyScripts.DarkenDinosaur.Managers
{
    [RequireComponent(typeof(AudioSource))]
    public class MusicManager : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private AudioSource audioSource;

        [Header("Sttings")]
        [SerializeField] List<AudioClip> backgroundMusicClips;


        private void Awake()
        {
            if (audioSource==null) audioSource = GetComponent<AudioSource>();

            MusicManager[] musicManagersOnScene = FindObjectsOfType<MusicManager>();

            if (musicManagersOnScene.Length > 1)
            {
                Destroy(this.gameObject);
            }

            else
            {
                DontDestroyOnLoad(this.gameObject);
            }
        }

        private void Update()
        {
            if (this.audioSource.isPlaying == false)
            {
                AudioClip clip = GetRandomTrack();
                this.audioSource.PlayOneShot(clip);
            }
        }

        AudioClip GetRandomTrack()
        {
            int i = Random.Range(0, backgroundMusicClips.Count);
            return backgroundMusicClips[i];
        }
    }
}