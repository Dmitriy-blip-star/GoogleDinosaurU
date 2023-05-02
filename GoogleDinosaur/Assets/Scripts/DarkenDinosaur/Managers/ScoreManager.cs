using DarkenDinosaur.Map;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] int addScorePerIteration; // количество очков за одну иттерацию
    [SerializeField] float iterationDelta; // Текущее время между итерациями
    [SerializeField] float minIterationDelta; // минимальное время между итерациями
    [SerializeField] float maxIterationDelta; // максимальное время между итерациями
    [SerializeField] float lessDeltaPerSecond; // значение на которое уменьшеается время между иттерациями каждую секунду
    [SerializeField] float nonLessDeltaTime; // время без уменьшения времени между иттерациями

    [Space]
    [SerializeField] int scoreCount; // значение счета
    [SerializeField] int highScoreCount; // рекорд 

    [SerializeField] UnityEvent<int> scoreChanged; // смена счета
    [SerializeField] UnityEvent<int> highScoreChanged; // смена максимального счета

    IEnumerator ScoreCounter()
    {
        while (true)
        {
            this.scoreCount += this.addScorePerIteration; // увеличиваем количество очков на количество очков за итерацию
            this.scoreChanged?.Invoke(scoreCount); // передача этого значение через событие

            if (this.scoreCount > this.highScoreCount) // если текущий счет больше максимального
            {
                this.highScoreCount = this.scoreCount; // присваиваем значение счета рекорду 
                this.highScoreChanged?.Invoke(this.highScoreCount);// и передаем это значение через событие
            }

            yield return new WaitForSeconds(this.iterationDelta); // задержка между итерациями
        }
    }

    IEnumerator IterationDeltaCounter()
    {
        yield return new WaitForSeconds(this.nonLessDeltaTime); // ждем до запуска куратины время без уменьшения времени между итерациями

        while (true)
        {
            this.iterationDelta -= this.lessDeltaPerSecond / 10; // уменьшеаем время между итерациями
            this.iterationDelta = Mathf.Clamp(this.iterationDelta, this.minIterationDelta, this.maxIterationDelta); // контролируем значение вермени между итерациями таким обрзом, чтобы оно не выходило за границы
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void OnGameStart()
    {
        StartCoroutine(ScoreCounter()); // увеличиваем значение счета
        StartCoroutine(IterationDeltaCounter()); // уменьшаем значение времени между итерациями
    }

    public void OnPlayerDead()
    {
        StopAllCoroutines(); // останавливаем все куратины, чтобы после смерти игрока счет не продолжал увеличиваться
    }

    public void OnDataLoaded(GameData data)
    {
        this.highScoreCount = data.highScoreCount;
    }
 }
