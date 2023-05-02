using System.Collections;
using UnityEngine;

namespace Assets.MyScripts.DarkenDinosaur.UI
{
    public class RestartTooltipsPresenter : MonoBehaviour
    {
        [Header("Game objects")]
        [SerializeField] GameObject restartTooltipscontainer;

        public void OnPlayerDead() => this.restartTooltipscontainer.SetActive(true);
    }
}