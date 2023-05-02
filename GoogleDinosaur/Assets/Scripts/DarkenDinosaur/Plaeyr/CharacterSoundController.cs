using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.MyScripts.DarkenDinosaur.Plaeyr
{
    [RequireComponent(typeof(AudioSource))]
    public class CharacterSoundController : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] AudioSource audioSource;

        [Header("Settings")]
        [SerializeField] List<AudioClip> jumpSound; // списки для хранения звуков
        [SerializeField] List<AudioClip> deadSound;


        private void Awake()
        {
            if (this.audioSource==null) this.audioSource = GetComponent<AudioSource>();
        }


        public void PlayJumpSound()
        {
            int i = Random.Range(0, this.jumpSound.Count); // генерация случайного числа по количеству элементов внутри списка
            this.audioSource.PlayOneShot(this.jumpSound[i]); // в зависимости от сгенерированного числа выбираем один из звуков внутри списка
        }

        public void PlayDeadSound()
        {
            int i = Random.Range(0, this.deadSound.Count);
            this.audioSource.PlayOneShot(this.deadSound[i]);
        }

    }
}