using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _cardPrefab;
    [SerializeField] private Transform _cardParentTransform;
    [SerializeField] private GameSettings _gameSettings;

    private List<Sprite> _faceSprites = new List<Sprite>();

    public void SpawnCards(int amount)
    {
        FillFaceSpritesList();

        List<Sprite> availableSprites = new List<Sprite>(amount / 2);

        availableSprites = GenerateNewSprites(amount);

        if (_gameSettings.IsNewGame)
        {
            ClearPastData();

            for (int i = 0; i < amount; i++)
            {
                int r = Random.Range(0, availableSprites.Count);

                CreateCard(i, availableSprites[r]);

                _gameSettings.WasFoundPair.Add(false);
                _gameSettings.SpriteIndexes.Add(_gameSettings.CardFaces.IndexOf(availableSprites[r])); //
                availableSprites.RemoveAt(r);
            }
        }

        else
        {
            for (int i = 0; i < amount; i++)
            {
                var card = CreateCard(i, _gameSettings.CardFaces[_gameSettings.SpriteIndexes[i]]);

                if (_gameSettings.WasFoundPair[i] == true)
                {
                    card.RemoveFromLocation();
                }
            }
        }
    }

    private void FillFaceSpritesList()
    {
        _faceSprites.Clear();

        for (int i = 0; i < _gameSettings.CardFaces.Count; i++)
        {
            _faceSprites.Add(_gameSettings.CardFaces[i]);
        }
    }

    private void ClearPastData()
    {
        _gameSettings.SpriteIndexes.Clear();
        _gameSettings.WasFoundPair.Clear();
    }

    private List<Sprite> GenerateNewSprites(int amount)
    {
        List<Sprite> availableSprites = new List<Sprite>(amount / 2);

        for (int i = 0; i < amount / 2; i++)
        {
            int r = Random.Range(0, _faceSprites.Count);

            for (int j = 0; j < 2; j++)
            {
                availableSprites.Add(_faceSprites[r]);
            }

            _faceSprites.RemoveAt(r);
        }

        return availableSprites;
    }

    private Card CreateCard(int id, Sprite faceSprite)
    {
        var card = Instantiate(_cardPrefab, _cardParentTransform);
        Card cardScript = card.GetComponent<Card>();

        cardScript.Initialize
            (_gameSettings.CardBack, faceSprite, id);

        return cardScript;
    }


}
