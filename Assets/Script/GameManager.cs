using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public enum GameState
    {
        Gameplay,
        Paused,
        GameOver
    }

    public GameState currentState;
    public GameState previousState;

    [Header("UI")]
    public GameObject pauseScreen;
    public GameObject resultScreen;

    public Text currentHealthDisplay;
    public Text currentRecoveryDisplay;
    public Text currentMoveSpeedDisplay;
    public Text currentMightDisplay;
    public Text currentProjectileSpeedDisplay;
    public Text currentMagnetDisplay;

    public bool isGameOver = false; 
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("EXTRA" + this + "DELETED");
            Destroy(gameObject);
        }
        DisableScreens();
    }


    void Update()
    {
 

        switch (currentState)
        {
            case GameState.Gameplay:
                checkForPauseAndResume(); 
                break;
            case GameState.Paused:
                checkForPauseAndResume();
                break;
            case GameState.GameOver:

                if (!isGameOver)
                {
                    isGameOver = true;
                    Debug.Log("Game is over");
                    DisplayResult();
                }
                break;
            default:
                Debug.LogWarning("STATE DOES NOT EXIST");
                break;
        }
    }

    public void ChangeState(GameState newsState)
    {
           currentState = newsState;
    }

    public void PauseGame()
    {
        if (currentState != GameState.Paused)
        {
            previousState = currentState;
            ChangeState(GameState.Paused);
            Time.timeScale = 0f;
            pauseScreen.SetActive(true);
            Debug.Log("Gamme is paused");
        }

    }

    public void ResumeGame()
    {
        if (currentState == GameState.Paused)
        {
            ChangeState(previousState);
            Time.timeScale = 1f;
            pauseScreen.SetActive(false);
            Debug.Log("Game is resumed");

        }
    }

    void checkForPauseAndResume()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(currentState == GameState.Paused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void DisableScreens()
    {
        pauseScreen.SetActive(false);
        resultScreen.SetActive(false);  
    }
    public void Gameover()
    {
        ChangeState(GameState.GameOver);
    }

    void DisplayResult()
    {
         resultScreen.SetActive(true);
    }
}
