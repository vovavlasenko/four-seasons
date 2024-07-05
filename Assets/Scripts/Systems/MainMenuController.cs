using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameData _gameData;
    [SerializeField] private BlackScreen _blackScreen;
    [SerializeField] private Button _continueButton;

    private void Start()
    {
        UpdateInterface();
    }

    public void ShowBlackScreenOnNewGameStart()
    {
        _blackScreen.Show(StartNewGame);
    }

    private void StartNewGame()
    {
        _gameData.IsNewGame = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ShowBlackScreenOnGameContinue()
    {
        _blackScreen.Show(ContinueGame);
    }

    private void ContinueGame()
    {
        _gameData.IsNewGame = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void UpdateInterface()
    {
        if (_gameData.CanContinueGame)
        {
            _continueButton.interactable = true;
        }

        else
        {
            _continueButton.interactable = false;
        }
    }
}
