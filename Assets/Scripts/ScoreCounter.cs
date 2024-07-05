using UnityEngine;
using TMPro;
using DG.Tweening;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private GameSettings _gameSettings;
    [SerializeField] private TextMeshProUGUI _scoreText;
    
    private int _score;

    private void Start()
    {
        if(_gameSettings.IsNewGame)
        {
            _score = 0;
            _gameSettings.CurrentScore = 0;
        }    

        else
        {
            _score = _gameSettings.CurrentScore;
        }

        RefreshTextDisplayed();
    }

    public void AddScore()
    {
        _score++;
        _gameSettings.CurrentScore = _score;
        RefreshTextDisplayed();
        _scoreText.transform.DOShakeScale(0.5f, 1);
    }

    private void RefreshTextDisplayed()
    {
        _scoreText.SetText($"{_score}");
    }
}
