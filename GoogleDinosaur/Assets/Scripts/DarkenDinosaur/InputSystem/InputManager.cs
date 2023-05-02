using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] bool isGameStarted;
    [SerializeField] bool isPlayerDead;

    [SerializeField] UnityEvent gameStart;
    [SerializeField] UnityEvent restartLevel;
    [SerializeField] UnityEvent jumpButtonDown;
    [SerializeField] UnityEvent crouchRunButtonDown;
    [SerializeField] UnityEvent crouchRunButtonUp;


    public void OnPlayerDead() => isPlayerDead = true;

    public void OnRestartLevelButtonDown()
    {
        if (isPlayerDead)
        {
            restartLevel?.Invoke();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            OnPlayButtonDown();
            OnJumpButtonDown();
            OnRestartLevelButtonDown();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow)) OnCrouchRunButtonDown();
        if (Input.GetKeyUp(KeyCode.DownArrow)) OnCrouchRunButtonUp();
    }

    public void OnPlayButtonDown()
    {
        if (this.isGameStarted == false)
        {
            this.isGameStarted = true;
            this.gameStart?.Invoke();
            Debug.Log("{<color=green><b>Input Log</b></color>} => [InputManager] - (<color=yellow>OnPlayButtonDown</color>) -> Game started.");
        }
    }

    public void OnJumpButtonDown()
    {
        this.jumpButtonDown?.Invoke();
        Debug.Log("{<color=green><b>Input Log</b></color>} => [InputManager] - (<color=yellow>OnJumpButtonDown</color>) -> Jump button down.");
    }

    public void OnCrouchRunButtonDown()
    {

        this.crouchRunButtonDown?.Invoke();
        Debug.Log("{<color=green><b>Input Log</b></color>} => [InputManager] - (<color=yellow>OnCrouchRunButtonDown</color>) -> Crouch run button down.");
    }

    public void OnCrouchRunButtonUp()
    {
        this.crouchRunButtonUp?.Invoke();
        Debug.Log("{<color=green><b>Input Log</b></color>} => [InputManager] - (<color=yellow>OnCrouchRunButtonUp</color>) -> Crouch run button up.");
    }


}
