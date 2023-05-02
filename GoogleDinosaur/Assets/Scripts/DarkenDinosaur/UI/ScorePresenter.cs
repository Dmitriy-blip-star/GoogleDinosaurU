using JetBrains.Annotations;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.MyScripts.DarkenDinosaur.UI
{
    [RequireComponent(typeof(Text))]

    public class ScorePresenter : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] Text scoreText;

        private void Awake()
        {
            if(scoreText == null) this.scoreText = GetComponent<Text>();
        }
        // выводим количество очков в текст
        public void OnScoreChanged(int score) => this.scoreText.text = score.ToString();
    }
}