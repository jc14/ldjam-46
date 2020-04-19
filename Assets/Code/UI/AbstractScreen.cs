using UnityEngine;

public abstract class AbstractScreen : MonoBehaviour
{
    protected GameManager gameManager;

    public void Open(GameManager gameManager)
    {
        OpenScreen();
        UpdateScreen(gameManager.Board);

        if (this.gameManager == null)
            this.gameManager = gameManager;
    }

    public void OpenScreen()
    {
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    protected abstract void UpdateScreen(Board board);
}
