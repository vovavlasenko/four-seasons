using UnityEngine;

[CreateAssetMenu(fileName = "Game Settings")]
public class GameSettings : ScriptableObject
{
    [Header("Grid")]
    public int RowsAmount;
    public int ColumnsAmount;


}
