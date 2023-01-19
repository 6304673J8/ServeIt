using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    //Which state is our game (MainMenu, Playing, Lost...) 
    public GameState State;
    
    public static event Action<GameState> OnGameStateChanged;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch (newState)
        {
            case GameState.StartGame:
                //HandleInitialScene();
                break;
            case GameState.PlayingTurnMorning:
                break;
            case GameState.PlayingTurnNight:
                break;
            case GameState.Victory:
                break;
            case GameState.GameOver:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnGameStateChanged?.Invoke(newState);
    }


    public enum GameState { 
        StartGame,
        PlayingTurnMorning,
        PlayingTurnNight,
        Victory,
        GameOver
    }
}
