using System.Collections;
using UnityEngine;

namespace Assets.MyScripts.DarkenDinosaur.Managers
{
    public class PauseManager : MonoBehaviour
    {
        public void Pause() =>  Time.timeScale = 0f;

        public void Continue() => Time.timeScale = 1f;
    }
}