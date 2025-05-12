using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("UI Components")]
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _highScoreText;
    [SerializeField] private GameObject _gameoverCanvas;

    [SerializeField] private String _highScorePlayerPref = "HighScore";

    [Header("Audio Clips")]
    [SerializeField] private AudioClip _buttonClick;

    private AudioSource _audioSource;

    private int _score;
    private int _highScore;

    void Awake()
    {
        _audioSource = gameObject.GetComponent<AudioSource>();
    }

    void Start()
    {
        _score = 0;
        _highScore = PlayerPrefs.GetInt(_highScorePlayerPref, 0);

        UpdateHighScoreUI();
    }

    public void GameOver()
    {
        Time.timeScale = 0.0f;
        _gameoverCanvas.SetActive(true);
    }

    public void Restart()
    {
        Time.timeScale = 1.0f;
        _audioSource.PlayOneShot(_buttonClick);
        SceneManager.LoadScene(0);
    }

    public void UpdateScore()
    {
        _score += 10;
        UpdateScoreUI();

        if (_score > _highScore)
        {
            SetHighScore();
            UpdateHighScoreUI();
        }
    }

    private void UpdateScoreUI()
    {
        _scoreText.text = $"Score: {_score}";
    }

    private void UpdateHighScoreUI()
    {
        _highScoreText.text = $"Previous Best: {_highScore}";
    }

    private void SetHighScore()
    {
        _highScore = _score;
        PlayerPrefs.SetInt(_highScorePlayerPref, _highScore);
    }
}
