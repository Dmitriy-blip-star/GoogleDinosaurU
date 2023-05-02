using DarkenDinosaur.Map;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] int addScorePerIteration; // ���������� ����� �� ���� ���������
    [SerializeField] float iterationDelta; // ������� ����� ����� ����������
    [SerializeField] float minIterationDelta; // ����������� ����� ����� ����������
    [SerializeField] float maxIterationDelta; // ������������ ����� ����� ����������
    [SerializeField] float lessDeltaPerSecond; // �������� �� ������� ������������ ����� ����� ����������� ������ �������
    [SerializeField] float nonLessDeltaTime; // ����� ��� ���������� ������� ����� �����������

    [Space]
    [SerializeField] int scoreCount; // �������� �����
    [SerializeField] int highScoreCount; // ������ 

    [SerializeField] UnityEvent<int> scoreChanged; // ����� �����
    [SerializeField] UnityEvent<int> highScoreChanged; // ����� ������������� �����

    IEnumerator ScoreCounter()
    {
        while (true)
        {
            this.scoreCount += this.addScorePerIteration; // ����������� ���������� ����� �� ���������� ����� �� ��������
            this.scoreChanged?.Invoke(scoreCount); // �������� ����� �������� ����� �������

            if (this.scoreCount > this.highScoreCount) // ���� ������� ���� ������ �������������
            {
                this.highScoreCount = this.scoreCount; // ����������� �������� ����� ������� 
                this.highScoreChanged?.Invoke(this.highScoreCount);// � �������� ��� �������� ����� �������
            }

            yield return new WaitForSeconds(this.iterationDelta); // �������� ����� ����������
        }
    }

    IEnumerator IterationDeltaCounter()
    {
        yield return new WaitForSeconds(this.nonLessDeltaTime); // ���� �� ������� �������� ����� ��� ���������� ������� ����� ����������

        while (true)
        {
            this.iterationDelta -= this.lessDeltaPerSecond / 10; // ���������� ����� ����� ����������
            this.iterationDelta = Mathf.Clamp(this.iterationDelta, this.minIterationDelta, this.maxIterationDelta); // ������������ �������� ������� ����� ���������� ����� ������, ����� ��� �� �������� �� �������
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void OnGameStart()
    {
        StartCoroutine(ScoreCounter()); // ����������� �������� �����
        StartCoroutine(IterationDeltaCounter()); // ��������� �������� ������� ����� ����������
    }

    public void OnPlayerDead()
    {
        StopAllCoroutines(); // ������������� ��� ��������, ����� ����� ������ ������ ���� �� ��������� �������������
    }

    public void OnDataLoaded(GameData data)
    {
        this.highScoreCount = data.highScoreCount;
    }
 }
