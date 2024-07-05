using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Button))]
public class GameModeButton : MonoBehaviour
{
    [SerializeField] private GameData _gameData;
    [SerializeField] private MainMenuController _mainMenuController;
    [SerializeField] private int _rows;
    [SerializeField] private int _columns;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(StartNewGame);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(StartNewGame);
    }

    private void StartNewGame()
    {
        _gameData.RowsAmount = _rows;
        _gameData.ColumnsAmount = _columns;
        _gameData.IsNewGame = true;
        _mainMenuController.ShowBlackScreenOnNewGameStart();
    }

}
