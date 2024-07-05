using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameModeButton : MonoBehaviour
{
    [SerializeField] private GameSettings _gameSettings;
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
        _gameSettings.RowsAmount = _rows;
        _gameSettings.ColumnsAmount = _columns;
        _gameSettings.IsNewGame = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}
