using UnityEngine;

public class StarsEffectsPresenter : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] GameObject staticParticle;
    [SerializeField] GameObject dynamicParticle;
    [SerializeField] Animator staticParticlesAnimator;

    static readonly int GameStart = Animator.StringToHash("GameStart");

    public void OnGameStart()
    {
        this.staticParticlesAnimator.SetTrigger(GameStart);
        this.dynamicParticle.SetActive(true);
    }
}
