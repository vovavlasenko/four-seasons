using System.Collections.Generic;
using UnityEngine;

public class CardSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _cardPrefab;
    [SerializeField] private Transform _cardParentTransform;
    [SerializeField] private GameData _gameData;

    private List<Sprite> _availableSprites = new List<Sprite>();
    private int _cardsAmount;

    public void SpawnCards(int amount)
    {
        _cardsAmount = amount;

        FillAvailableSpritesList();

        if (_gameData.IsNewGame)
        {
            SpawnCardsForNewGame(SelectSpritesForLayout());
        }

        else
        {
            SpawnPastCardLayout();
        }
    }

    private void FillAvailableSpritesList()
    {
        _availableSprites.Clear();

        for (int i = 0; i < _gameData.CardFaces.Count; i++)
        {
            _availableSprites.Add(_gameData.CardFaces[i]);
        }
    }

    private void SpawnCardsForNewGame(List<Sprite> selectedSprites) // If we start a new game
    {
        ClearPastData();

        for (int i = 0; i < _cardsAmount; i++)
        {
            int r = Random.Range(0, selectedSprites.Count);

            CreateCard(i, selectedSprites[r]);
            _gameData.CardsLeftOnScene++;
            _gameData.WasFoundPair.Add(false);
            _gameData.SpriteIndexes.Add(_gameData.CardFaces.IndexOf(selectedSprites[r]));
            selectedSprites.RemoveAt(r);
        }
    }

    private void SpawnPastCardLayout() // If we continue game
    {
        for (int i = 0; i < _cardsAmount; i++)
        {
            var card = CreateCard(i, _gameData.CardFaces[_gameData.SpriteIndexes[i]]);

            if (_gameData.WasFoundPair[i] == true)
            {
                card.RemoveFromLocation();
            }
        }
    }

    private List<Sprite> SelectSpritesForLayout()
    {
        List<Sprite> selectedSprites = new List<Sprite>(_cardsAmount / 2);

        for (int i = 0; i < _cardsAmount / 2; i++)
        {
            int r = Random.Range(0, _availableSprites.Count);

            for (int j = 0; j < 2; j++)
            {
                selectedSprites.Add(_availableSprites[r]);
            }

            _availableSprites.RemoveAt(r);
        }

        return selectedSprites;
    }

    private void ClearPastData() 
    {
        _gameData.SpriteIndexes.Clear();
        _gameData.WasFoundPair.Clear();
        _gameData.CardsLeftOnScene = 0;
    }

    private Card CreateCard(int id, Sprite faceSprite)
    {
        var card = Instantiate(_cardPrefab, _cardParentTransform);
        Card cardScript = card.GetComponent<Card>();

        cardScript.Initialize
            (_gameData.CardBack, faceSprite, id);

        return cardScript;
    }


}
