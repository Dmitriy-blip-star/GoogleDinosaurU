using DarkenDinosaur.Map;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.MyScripts.DarkenDinosaur.UI
{
    [RequireComponent(typeof(Text))]
    public class HgihScorePresenter : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] Text highScoreText;
        
        [Header("Settings")]
        [SerializeField] string prefix;

        private void Awake()
        {
            if(highScoreText == null) highScoreText = GetComponent<Text>();
        }

        public void OnDataLoaded(GameData data) => 
            this.highScoreText.text = $"{this.prefix} {data.highScoreCount}";

        // выводим количество очков в текст. В начале идет приставка, которую мы позже сможем вписать через инспектор
        public void OnHighScoreChanged(int highScore) => this.highScoreText.text = $"{this.prefix} {highScore}";
    }
}