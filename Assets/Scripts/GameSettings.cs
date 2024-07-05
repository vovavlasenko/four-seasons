using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Game Settings")]
public class GameSettings : ScriptableObject
{
    [Header("Grid")]
    public int RowsAmount;
    public int ColumnsAmount;

    [Header("Cards")]
    public Sprite CardBack;
    public List<Sprite> CardFaces;
    public List<int> SpriteIndexes = new List<int>();
    public List<bool> WasFoundPair = new List<bool>();
    public int CardsLeftOnScene;

    [Header("Other")]
    public int CurrentScore;
    public bool IsNewGame;
    public bool CanContinueGame;

}
