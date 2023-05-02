using System.Collections;
using UnityEngine;

namespace Assets.MyScripts.DarkenDinosaur.Plaeyr
{
    [RequireComponent(typeof(Animator))]
    public class CharacterAnimationController : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] Animator animator;
        [SerializeField] CharacterMovementController characterMovement;


        // идентификаторы свойств аниматора
        static readonly int GameStartTrigger = Animator.StringToHash("GameStart"); // переключает анимацию из состояния покоя в состояние бега при старте игры
        static readonly int JumpTrigger = Animator.StringToHash("Jump"); // переключает анимацию в состояние прыжка
        static readonly int IsGround = Animator.StringToHash("IsGround"); // свойство отвечающее за то, находится ли персонаж на земле
        static readonly int IsCrouchRun = Animator.StringToHash("IsCrouchRun"); // свойство отвечающее за то, нажата ли у игрока кнопка бега пригнувшись


        private void Awake()
        {
            if (this.animator == null) this.animator = GetComponent<Animator>();
            if (this.characterMovement == null) this.characterMovement = GetComponent<CharacterMovementController>();
        }

        private void Update()
        {
            bool isGround = this.characterMovement.IsGround(); // получаем значение метода isGround, отвечающего за нахождение на земле
            SetIsGround(isGround); // присваиваем свойству из аниматора это значение 
        }


        // методы отвечающие за управление идентификаторами свойств анимации
        public void SetJump() => this.animator.SetTrigger(JumpTrigger);
        public void SetGameStart() => this.animator.SetTrigger(GameStartTrigger);
        public void SetIsGround(bool value) => this.animator.SetBool(IsGround, value);
        public void SetCrouchRun(bool value) => this.animator.SetBool(IsCrouchRun, value);
    }
}