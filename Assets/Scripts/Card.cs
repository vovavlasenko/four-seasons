using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;
using DG.Tweening;

public class Card : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image _cardImage;

    public static event Action<Card> SelectCard;

    private Sprite _faceSprite;
    private Sprite _backSprite;
    private bool _canRotate = true;
    private bool _pairWasFound = false;

    public Sprite FaceSprite { get => _faceSprite; }

    public void Initialize(Sprite backSprite, Sprite faceSprite)
    {
        _backSprite = backSprite;
        _faceSprite = faceSprite;
        _cardImage.sprite = _backSprite;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_canRotate && !_pairWasFound)
        {
            StartRevealingCard();
        }
    }

    private void StartRevealingCard()
    {
        _canRotate = false;
        CardFlipWithCallback(90f, FinishRevealingCard);
    }

    private void CardFlipWithCallback(float angle, Action callback)
    {
        Tween t = _cardImage.transform.DORotate(new Vector3(0f, angle, 0f), 0.25f);
        t.OnComplete(() => callback());
    }

    private void FinishRevealingCard()
    {
        _cardImage.sprite = _faceSprite;
        CardFlipWithCallback(180f, OnCardSelected);
    }

    public void StartUnrevealingCard()
    {
        CardFlipWithCallback(90f, FinishUnrevealingCard);
    }

    private void FinishUnrevealingCard()
    {
        _cardImage.sprite = _backSprite;
        CardFlipWithCallback(0f, EnableRotating);
    }

    private void EnableRotating()
    {
        _canRotate = true;
    }

    private void OnCardSelected()
    {
        SelectCard?.Invoke(this);
    }

    public void OnPairFound()
    {
        _canRotate = false;
        _pairWasFound = true;
        _cardImage.transform.DOScale(0, 0.5f);
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
       // transform.localScale = new Vector3(1.1f, 1.1f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
       // transform.localScale = new Vector3(1f, 1f);
    }
}
