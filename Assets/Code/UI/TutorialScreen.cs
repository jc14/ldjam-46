using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScreen : AbstractScreen
{
    public Button GotItButton;

    private void Awake()
    {
        GotItButton.onClick.AddListener(HandleGotItButton);
    }

    protected override void UpdateScreen(Board board)
    {
        throw new System.NotImplementedException();
    }

    private void HandleGotItButton()
    {
        Close();
    }
}
