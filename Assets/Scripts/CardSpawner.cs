using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _cardPrefab;
    [SerializeField] private Transform _cardParentTransform;
    [SerializeField] private List<Sprite> _faceSprites;
    [SerializeField] private Sprite _backSprite;

    public void SpawnCards(int amount)
    {
        List<Sprite> availableSprites = new List<Sprite>(amount/2);

        for (int i = 0; i < amount/2; i++)
        {
            int r = Random.Range(0, _faceSprites.Count);

            for (int j = 0; j < 2; j++)
            {
                availableSprites.Add(_faceSprites[r]);
            }
           
            _faceSprites.RemoveAt(r);
        }

        for (int i = 0; i < amount; i++)
        {
            int r = Random.Range(0, availableSprites.Count);
            var card = Instantiate(_cardPrefab, _cardParentTransform);
            card.GetComponent<Card>().Initialize(_backSprite, availableSprites[r]);
            availableSprites.RemoveAt(r);
        }
    }
}
