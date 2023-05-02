using System.Collections;
using UnityEngine;

namespace Assets.MyScripts.DarkenDinosaur.UI
{
    public class TooltipsPresenter : MonoBehaviour
    {
        [SerializeField] GameObject tooltipsContainer;

        public void OnGameStart() => tooltipsContainer.SetActive(false);
    }
}