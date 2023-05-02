using DarkenDinosaur.Map;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.MyScripts.DarkenDinosaur.Managers
{
    public class SaveManager : MonoBehaviour
    {
        [Header("Game data")]
        [Tooltip("Game data structure")]
        [SerializeField] GameData gameData; // модель игры(данные)

        [Header("Settings")]
        [Tooltip("Save file name")]
        [SerializeField] string saveFileName; // название файла с файлами сохранения

        [Tooltip("Save directory name")]
        [SerializeField] string saveDirectoryName; // название папки с файлами сохранения

        [Tooltip("Path to save directory")]
        [SerializeField] string saveDirectoryPath; // путь до папки с сохранениями

        [Tooltip("Path to save file")]
        [SerializeField] string saveFilePath; // полный путь до файла с сохранением

        [SerializeField] UnityEvent<GameData> dataLoaded;
        [SerializeField] UnityEvent<GameData> dataSaved;

        void SaveDataToFile()
        {
            string json = JsonUtility.ToJson(gameData);
            File.WriteAllText(saveFilePath, json);
            dataSaved?.Invoke(gameData);
        }

        private void Awake()
        {
#if UNITY_ANDROID || UNITY_IOS
            // заполняем пути к сохранениям
            this.saveDirectoryPath = Path.Combine(Application.persistentDataPath, this.saveDirectoryName);
            this.saveFilePath = Path.Combine(Application.persistentDataPath, this.saveDirectoryName, saveFileName);
#endif
#if UNITY_STANDALONE || UNITY_EDITOR
            this.saveDirectoryPath = Path.Combine(Application.dataPath, this.saveDirectoryName);
            this.saveFilePath = Path.Combine(Application.dataPath, this.saveDirectoryName, saveFileName);
#endif
            // если директории с сохранениями не существует, то создаем ее
            if (Directory.Exists(this.saveDirectoryPath) == false)
            {
                Debug.Log("{<color=blue><b>Save Manager Log</b></color>} => [SaveManager] - (<color=yellow>Awake</color>) -> Save directory created.");
                Directory.CreateDirectory(this.saveDirectoryPath);
            }

            // проверяем наличие файла с сохранением и если он есть, то пытаемся зугрузить его
            if (File.Exists(this.saveFilePath))
            {
                string json = File.ReadAllText(this.saveFilePath);
                GameData gameDataFromJson = JsonUtility.FromJson<GameData>(json);
                this.gameData = gameDataFromJson;
                Debug.Log("{<color=blue><b>Save Manager Log</b></color>} => [SaveManager] - (<color=yellow>Awake</color>) -> Data loaded from file.");
                this.dataLoaded?.Invoke(this.gameData);
            }
        }

        private void OnApplicationPause(bool pauseStatus)
        {
#if UNITY_ANDROID || UNITY_IOS
            SaveDataToFile();
#endif
        }

        private void OnApplicationQuit()
        {
            SaveDataToFile();
        }

        public void OnHighScoreChanged(int highScore) => gameData.highScoreCount = highScore;
        

    }
}