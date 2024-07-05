using UnityEngine;
using TMPro;
using DG.Tweening;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    private int _score;

    private void Start()
    {
        RefreshTextDisplayed();
    }

    public void AddScore()
    {
        _score++;
        RefreshTextDisplayed();
    }

    private void RefreshTextDisplayed()
    {
        _scoreText.SetText($"{_score}");
        _scoreText.transform.DOShakeScale(0.5f, 1);

    }
}
