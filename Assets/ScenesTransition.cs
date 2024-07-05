using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesTransition : MonoBehaviour
{
    [SerializeField] private GameSettings _gameSettings;
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

    private void CheckWinCondition()
    {
        if (_gameSettings.CardsLeftOnScene == 0)
        {
            _soundSystem.PlayGameOverSound();
            _gameSettings.CanContinueGame = false;
            _blackScreen.Show(ExitToMainMenu);
        }    
    }

}
