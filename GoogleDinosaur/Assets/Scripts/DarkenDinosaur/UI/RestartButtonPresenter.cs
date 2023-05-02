using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButtonPresenter : MonoBehaviour
{
    [Header("Game objects")]
    [SerializeField] GameObject restartButton;

    public void OnPlayerDead() => this.gameObject.SetActive(true);
}
