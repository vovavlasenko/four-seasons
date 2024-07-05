using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(GridLayoutGroup))]

public class TableGenerator : MonoBehaviour
{
    [SerializeField] private GameSettings _gameSettings;
    [SerializeField] private CardSpawner _cardSpawner;

    private RectTransform _rectTransform;
    private GridLayoutGroup _grid;
    private int _rows;
    private int _columns;
    private float _spacingX;
    private float _spacingY;
    private float _maxPossibleCardWidth;
    private float _maxPossibleCardHeight;


    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _grid = GetComponent<GridLayoutGroup>();
    }

    private void Start()
    {
        GetLayoutInfo();
        CalculateMaxPossibleCardSize();
        SetGridSpacing();
        SetGridConstraint();
        SetFinalCardSize();
        SpawnCards();
        _gameSettings.CanContinueGame = true;
    }
    
    private void GetLayoutInfo()
    {
        _rows = _gameSettings.RowsAmount;
        _columns = _gameSettings.ColumnsAmount;
    }

    private void CalculateMaxPossibleCardSize()
    {
        _maxPossibleCardWidth = _rectTransform.sizeDelta.x / _columns;
        _maxPossibleCardHeight = _rectTransform.sizeDelta.y / _rows;
    }

    private void SetGridSpacing() // Spacing between the cards is calculated as 10% from max card size
    {       
        _spacingX = _maxPossibleCardWidth / 10;
        _spacingY = _maxPossibleCardHeight / 10;
        _grid.spacing = new Vector2(_spacingX, _spacingY);
    }

    private void SetGridConstraint()
    {
        _grid.constraintCount = _rows;
    }

    private void SetFinalCardSize()
    {
        float cardWidth = _maxPossibleCardWidth - _spacingX;
        float cardHeight = _maxPossibleCardHeight - _spacingY;
        float cardSide = Mathf.Min(cardWidth, cardHeight); 
        _grid.cellSize = new Vector2(cardSide, cardSide); // Making card square-shaped
    }

    private void SpawnCards()
    {
       _cardSpawner.SpawnCards(_rows * _columns);
    }

}
