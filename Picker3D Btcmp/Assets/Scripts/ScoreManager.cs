using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private int _score;
    private int _levelScore;
    [SerializeField] TextMeshProUGUI scoreText;
    void Start()
    {
        _levelScore = 0;
        scoreText.text = PlayerPrefs.GetInt("Score", _score).ToString();
    }
    void Update()
    {
        scoreText.text = PlayerPrefs.GetInt("Score", _score).ToString();
    }
    public void IncreaseScore()
    {
        _score++;
        PlayerPrefs.SetInt("Score", _score);
    }
    public void IncreaseLevelScore()
    {
        _levelScore++;
    }
    public void SetToZeroLevelScore()
    {
        _levelScore = 0;
    }
    public int GetLevelScore()
    {
        return _levelScore;
    }
}
