using JetBrains.Annotations;
using System.Collections;
using UnityEngine;

namespace Assets.MyScripts.DarkenDinosaur.Sound
{
    [RequireComponent(typeof(AudioSource))]

    public class ScoreSoundController : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] AudioSource audioSource;

        [Header("Settings")]
        [SerializeField] AudioClip scoreEven100Sound;
        [SerializeField] AudioClip scoreEven250Sound;
        [SerializeField] AudioClip scoreEven500Sound;

        private void Awake()
        {
            if (audioSource == null) audioSource = GetComponent<AudioSource>();
        }

        bool IsEvenNumber(int value, int number) => value % number == 0; // метод для проверки четности чисел(счета на рекорды)

        public void OnScoreChanged(int score)
        {
            // если значение счета будет кратно одному из чисел, то будет проигрываться соответствующий звук
            if (IsEvenNumber(score, 500)) this.audioSource.PlayOneShot(this.scoreEven500Sound);
            else if (IsEvenNumber(score, 250)) this.audioSource.PlayOneShot(this.scoreEven250Sound);
            else if (IsEvenNumber(score, 100)) this.audioSource.PlayOneShot(this.scoreEven100Sound);
        }
    }
}