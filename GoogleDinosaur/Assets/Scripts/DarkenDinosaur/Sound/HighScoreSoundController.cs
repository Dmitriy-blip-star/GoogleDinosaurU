using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.MyScripts.DarkenDinosaur.Sound
{
    [RequireComponent(typeof(AudioSource))]

    public class HighScoreSoundController : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] AudioSource audioSource;

        [Header("Settings")]
        [SerializeField] List<AudioClip> highScoreChangedSounds; // лист со звуками
        [SerializeField] bool isSoundPlayed; // поле нужно для того, чтобы звук обновления рекорда проигрывался только один раз

        private void Awake()
        {
            if (audioSource == null) audioSource = GetComponent<AudioSource>();
        }

        public void OnHighScoreChanged(int highScore)
        {
            if (isSoundPlayed == false)
            {
                this.isSoundPlayed = true;
                int i = Random.Range(0, this.highScoreChangedSounds.Count); // генерируем случайное число от 0 до количесва элементов в листе со звуками
                this.audioSource.PlayOneShot(this.highScoreChangedSounds[i]); // и воспроизводим звук с этим индексом
            }
        }
    }
}