using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardUI : MonoBehaviour
{
    public CaseNumberPanel CaseNumberPanel;
    public Button EndTurnButton;

    private Board board;

    private void Awake()
    {
        board = GetComponent<Board>();

        EndTurnButton.onClick.AddListener(HandleEndTurn);
    }

    public void OnStartNewGame()
    {
        CaseNumberPanel.SetCaseNumber(board.CaseNumber);
    }

    private void HandleEndTurn()
    {
        board.EndRound();
    }
}
