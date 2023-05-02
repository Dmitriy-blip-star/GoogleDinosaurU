using System.Collections;
using UnityEngine;

namespace Assets.MyScripts.DarkenDinosaur.Plaeyr
{
    [RequireComponent(typeof(Rigidbody2D))]

    public class CharacterMovementController : MonoBehaviour
    {

        [Header("Components")]
        [SerializeField] Rigidbody2D rb;

        [Header("Settings")]
        [SerializeField] float detectedRayLenght; // длинна луча, столкновение с землей которого будет определять стоит ли персонаж на земле
        [SerializeField] float jumpForce;

        [Header("Development settings")]
        [SerializeField] bool showDetectedGroundRay; // свойство отвечающее за отображение подцветки луча

        private void Awake()
        {
            if (this.rb == null) this.rb = GetComponent<Rigidbody2D>(); // если компонент не определен, подтянем его перед стартом игры
        }

        private void Update()
        {
            if (showDetectedGroundRay) 
            {
                Debug.DrawRay(transform.position, Vector3.down * this.detectedRayLenght, Color.red);// подсвечиваем луч определяющий столкновение с коллайдерами
            }
        }

        public bool IsGround() // проверка находится ли персонаж на земле
        {

            int groundLayerMask = LayerMask.GetMask("Ground"); // слой, отвечающий за землю
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, this.detectedRayLenght, groundLayerMask);// метод принимает 4 параметра. 1. откуда выпускается луч. 2. куда выпускается луч
                                                                                                                            // 3. длина луча 4. слой с которым будет взаимодействовать луч
            return hit.collider; // если в колайдере что-то будет вернется true, если нет false
        }

        public void Jump() => this.rb.AddForce(Vector2.up * this.jumpForce, ForceMode2D.Impulse); // прыжок
    }
}