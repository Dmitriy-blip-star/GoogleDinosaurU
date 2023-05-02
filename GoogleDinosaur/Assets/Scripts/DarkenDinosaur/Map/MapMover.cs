using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace DarkenDinosaur.Map
{
    public class MapMover : MonoBehaviour
    {
        [Header ("Settings")]
        [Tooltip("Minimum moving speed")]
        [SerializeField] float minSpeed;

        [Tooltip("Maximum moving speed")]
        [SerializeField] float maxSpeed;

        [Tooltip("Curent speed")]
        [SerializeField] float speed;

        [Tooltip("Boost moving speed per second")]
        [SerializeField] float boostySpeedPerSecond;

        [SerializeField] float nonBoostSpeedTime;

        [SerializeField] bool isPlay;

        private void Update()
        {
            if (this.isPlay) // если значение флага == true
            {
                Vector3 position = transform.position;
                position = Vector3.Lerp(position, position + Vector3.left, Time.deltaTime * this.speed); // двигаем объект
                transform.position= position;
            }
        }

        private IEnumerator SpeedCounter() // Куратина для постепенного увеличения скорости карты
        {

            yield return new WaitForSeconds(this.nonBoostSpeedTime); // время без буста скорости карты

            while (true)
            {
                yield return new WaitForSeconds(0.1f); // время перед каждым увеличением скорости движения карты
                this.speed += boostySpeedPerSecond / 10; // буст скорости карты
                this.speed = Mathf.Clamp(this.speed, this.minSpeed, this.maxSpeed); // ограничение скорости карты не меньше минимального, не больше максимального
            }
        }

        public void OnGameStart()
        {
            StartCoroutine(SpeedCounter());
            this.isPlay = true;
        }

        public void OnPause() => this.isPlay= false; // метод паузы
         
        public void onContinue() => this.isPlay= true; // метод старта игры

    }
}