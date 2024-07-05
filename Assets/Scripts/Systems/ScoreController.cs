using UnityEngine;
using TMPro;
using DG.Tweening;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private GameData _gameData;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _comboText;
    
    private int _score;

    private void OnEnable()
    {
        CardComparator.PairFound += AddScore;
    }

    private void OnDisable()
    {
        CardComparator.PairFound -= AddScore;
    }

    private void Start()
    {
        if(_gameData.IsNewGame)
        {
            _score = 0;
            _gameData.CurrentScore = 0;
        }    

        else
        {
            _score = _gameData.CurrentScore;
        }

        RefreshTextDisplayed();
    }

    public void AddScore(int comboMultiplier)
    {
        _score += comboMultiplier;
        _gameData.CurrentScore = _score;
        RefreshTextDisplayed();
        _scoreText.transform.DOShakeScale(0.5f, 1);

        if (comboMultiplier > 1)
        {
            DisplayComboText(comboMultiplier);
        }
    }

    private void RefreshTextDisplayed()
    {
        _scoreText.SetText($"{_score}");
    }

    private void DisplayComboText(int comboMultiplier)
    {
        int shakeValue = Mathf.Clamp(comboMultiplier, 2, 3);
        _comboText.gameObject.SetActive(true);
        _comboText.SetText($"COMBO x{comboMultiplier}");
        _scoreText.transform.DOShakeScale(1f, shakeValue).OnComplete(() =>
        _comboText.gameObject.SetActive(false));
    }
}
