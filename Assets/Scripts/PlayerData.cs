using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    public int RowsAmount;
    public int ColumnsAmount;
    public Sprite CardBack;
    public List<Sprite> CardFaces;
    public List<int> SpriteIndexes = new List<int>();
    public List<bool> WasFoundPair = new List<bool>();

    //public PlayerData(int row)
}
