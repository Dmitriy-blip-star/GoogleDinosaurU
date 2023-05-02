using UnityEngine;

public class ControlButtonPresenter : MonoBehaviour
{
    [Header("Game object")]
    [SerializeField] GameObject controlButtonContainer;

    public void OnGameStart() => controlButtonContainer.SetActive(true);

}
