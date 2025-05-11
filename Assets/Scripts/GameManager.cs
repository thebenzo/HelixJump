using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _scoreText;

    [SerializeField]
    private TMP_Text _highScoreText;

    [SerializeField]
    private GameObject _gameoverCanvas;

    private int _score;
    private int _highScore;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _score = 0;
        _highScore = PlayerPrefs.GetInt("HighScore", 0);
        String highScoreText = "Previous Best: " + _highScore.ToString();
        _highScoreText.text = highScoreText;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        Time.timeScale = 0.0f;
        _gameoverCanvas.SetActive(true);
    }

    public void Restart()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }

    public void UpdateScore()
    {
        _score += 10;
        String scoreText = "Score: " + _score.ToString();
        _scoreText.text = scoreText;

        if (_score > _highScore)
        {
            UpdateHighScore();
        }
    }

    public void UpdateHighScore()
    {
        _highScore = _score;
        PlayerPrefs.SetInt("HighScore", _highScore);

        String highScoreText = "Previous Best: " + _highScore.ToString();
        _highScoreText.text = highScoreText;
    }
}
