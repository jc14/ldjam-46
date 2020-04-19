using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Board Board;
    [Space(15)]
    public GameObject MainMenuPanel;
    public EndGameScreen EndGameScreen;
    [Space(10)]
    public Button ContinueGameButton;
    public Button NewGameButton;
    public Button ExitGameButton;

    private bool isMainMenuOpen = false;

    private void Awake()
    {
        ContinueGameButton.onClick.AddListener(HandleContinueGame);
        NewGameButton.onClick.AddListener(HandleNewGame);
        ExitGameButton.onClick.AddListener(HandleExitGame);

        OpenMainMenu();
    }

    private void OnApplicationQuit()
    {
        ContinueGameButton.onClick.RemoveAllListeners();
        NewGameButton.onClick.RemoveAllListeners();
        ExitGameButton.onClick.RemoveAllListeners();
    }

    public void ToggleMainMenu()
    {
        Debug.Log($"{isMainMenuOpen} | {Board.IsPlayingGame}");
        if (isMainMenuOpen && Board.IsPlayingGame)
        {
            CloseMainMenu();
            return;
        }

        if (isMainMenuOpen == false)
            OpenMainMenu();
    }

    public void OpenEndGameScreen()
    {
        CloseAllScreens();

        EndGameScreen.Open(this);
    }

    private void CloseEndGameScreen()
    {
        EndGameScreen.Close();
    }

    private void CloseAllScreens()
    {
        CloseMainMenu();
        CloseEndGameScreen();
    }

    private void OpenMainMenu()
    {
        CloseAllScreens();

        if (Board.IsPlayingGame)
        {
            ContinueGameButton.interactable = true;
        }
        else
        {
            ContinueGameButton.interactable = false;
        }

        MainMenuPanel.SetActive(true);
        isMainMenuOpen = true;
    }

    private void CloseMainMenu()
    {
        MainMenuPanel.SetActive(false);
        isMainMenuOpen = false;
    }

    private void HandleContinueGame()
    {
        CloseMainMenu();
    }

    private void HandleNewGame()
    {
        Board.StartNewGame();
        CloseAllScreens();
    }

    private void HandleExitGame()
    {
        Application.Quit();
    }
}
