using Assets.MyScripts.DarkenDinosaur.Plaeyr;
using UnityEngine;
using UnityEngine.Events;


// ���������� ��� ����� ���������� ������� ��� ���������
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(CharacterMovementController))]
[RequireComponent(typeof(CharacterAnimationController))]
[RequireComponent(typeof(CharacterSoundController))]

public class Character : MonoBehaviour // ����� �������������� ������ ���� ��� ������ ���������. ��� ����������� ������� �������, ������� ������ ����� ������������ ��������, ����� ���������� �����
{
    [Header("Components")]
    [SerializeField] CharacterMovementController characterMovement;
    [SerializeField] CharacterAnimationController characterAnimation;
    [SerializeField] CharacterSoundController characterSound;

    // �������
    [SerializeField] UnityEvent jump;
    [SerializeField] UnityEvent dead;
    [SerializeField] UnityEvent crouchRunStart;
    [SerializeField] UnityEvent crouchRunEnd;



    private void Awake()
    {
        if (this.characterAnimation == null) this.characterAnimation = GetComponent<CharacterAnimationController>();
        if (this.characterMovement == null) this.characterMovement = GetComponent<CharacterMovementController>();
        if (this.characterSound == null) this.characterSound = GetComponent<CharacterSoundController>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Obstacle":
                this.characterSound.PlayDeadSound();
                this.dead?.Invoke();
                Debug.Log("{<color=lime><b>Character Log</b></color>} => [Character] - (<color=yellow>OnCollisionEnter2D</color>) -> Character dead.");
                break;
        }
    }

    public void OnJumpButtonDown() // ����� ������ ������ ������ ���������
    {
        bool isGround = this.characterMovement.IsGround(); 

        if (isGround) // ���� �������� ��������� �� �����
        {
            // ��������� ����������� ������ �� ����������� ���������� �����

            this.characterMovement.Jump();
            this.characterAnimation.SetJump();
            this.characterSound.PlayJumpSound();
            this.jump?.Invoke();
        }
    }

    public void OnCrouchRunButtonDown()
    {
        bool isGround = this.characterMovement.IsGround();
        if (isGround)
        {
            this.characterAnimation.SetCrouchRun(true);
            this.crouchRunStart?.Invoke();
            
        }
    }

    public void OnCrouchRunButtonUp()
    {
        bool isGround = this.characterMovement.IsGround();
        if (isGround)
        {
            this.characterAnimation.SetCrouchRun(false);
            this.crouchRunEnd?.Invoke();
        }
    }

    public void OnGameStart()
    {
        this.characterAnimation.SetGameStart();
    }

}
