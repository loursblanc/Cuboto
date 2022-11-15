using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager
{

    public enum GAMESTATE
    {
        Running,
        Paused,
        Over
    }

    public delegate void gameStateChange(GAMESTATE gameState);
    public static event gameStateChange GameStateChanged;
    private static GAMESTATE _gameState;
    public static GAMESTATE GameState
    {
        get { return _gameState; }
        set
        {
            if (value != _gameState)
            {
                _gameState = value;

                switch (_gameState)
                {
                    case GAMESTATE.Running:
                        Time.timeScale = 1;
                        break;
                    case GAMESTATE.Paused:
                        Time.timeScale = 0;
                        break;
                    case GAMESTATE.Over:
                        Time.timeScale = 0;
                        break;
                    default:
                        Time.timeScale = 1;
                        break;
                }

                if(GameStateChanged != null)
                {
                    GameStateChanged(_gameState);
                }
            }
        }
    }


    public delegate void ScoreChange(int score);
    public static event ScoreChange ScoreChanged;
    private static int _currentScore = 0;
    public static int CurrentScore
    {
        get { return _currentScore; }
        set
        {
            _currentScore = value;
            if(ScoreChanged != null)
            {
                ScoreChanged(_currentScore);
            }
        }


    }
    
    
}
