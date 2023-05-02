using UnityEngine;

public class PlayButtonPresenter : MonoBehaviour
{
    [Header("Game object")]
    [SerializeField] GameObject playButton;

    public void OnGameStart() => playButton.SetActive(false);
 }
