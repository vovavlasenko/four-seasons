using System;
using UnityEngine;

public class CardComparator : MonoBehaviour
{
    [SerializeField] private GameSettings _gameSettings;
    [SerializeField] private SoundSystem _soundSystem;

    public static event Action PairFound;

    private Card _firstCard;
    private Card _secondCard;

    private void OnEnable()
    {
        Card.CardRevealed += OnCardSelect;
    }

    private void OnDisable()
    {
        Card.CardRevealed -= OnCardSelect;
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
            _soundSystem.PlayMatchSound();
            _firstCard.OnPairFound();
            _secondCard.OnPairFound();
            _gameSettings.CardsLeftOnScene -= 2;
             PairFound?.Invoke();
        }

        else
        {
            _soundSystem.PlayMismatchSound();
            _firstCard.StartUnrevealingCard();
            _secondCard.StartUnrevealingCard();
        }
    }
}
