using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private GameData _gameData;
    [SerializeField] private SoundSystem _soundSystem;
    [SerializeField] private BlackScreen _blackScreen;

    private void OnEnable()
    {
        CardComparator.PairFound += CheckWinCondition;
    }

    private void OnDisable()
    {
        CardComparator.PairFound -= CheckWinCondition;
    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void CheckWinCondition(int i)
    {
        if (_gameData.CardsLeftOnScene == 0)
        {
            GameOver();
        }    
    }

    private void GameOver()
    {
        _soundSystem.PlayGameOverSound();
        _gameData.CanContinueGame = false;
        _blackScreen.Show(ExitToMainMenu);
    }

}
