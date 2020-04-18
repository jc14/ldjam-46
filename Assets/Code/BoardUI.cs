using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardUI : MonoBehaviour
{
    public Button EndTurnButton;
    
    private Board board;

    private void Awake()
    {
        board = GetComponent<Board>();
    }

    private void HandleEndTurn()
    {
        board.StartRound();
    }
}
