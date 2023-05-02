using UnityEngine;
using UnityEngine.SceneManagement;


namespace Assets.MyScripts.DarkenDinosaur.Managers
{
    public class GameSceneManager : MonoBehaviour
    {
        public void OnRestartLevel() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}