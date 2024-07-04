using UnityEngine;

public class CardComparator : MonoBehaviour
{
    [SerializeField] private ScoreCounter _scoreCounter;

    private Card _firstCard;
    private Card _secondCard;

    private void OnEnable()
    {
        Card.SelectCard += OnCardSelect;
    }

    private void OnDisable()
    {
        Card.SelectCard -= OnCardSelect;
    }

    public void OnCardSelect(Card card)
    {
        if (_firstCard == null)
        {
            _firstCard = card;
        }

        else
        {
            _secondCard = card;
            CompareCards();
            _firstCard = null;
        }
    }

    private void CompareCards()
    {
        if (_firstCard.FaceSprite == _secondCard.FaceSprite)
        {
            _firstCard.OnPairFound();
            _secondCard.OnPairFound();
            _scoreCounter.AddScore();
        }

        else
        {
            _firstCard.StartUnrevealingCard();
            _secondCard.StartUnrevealingCard();
        }
    }
}
