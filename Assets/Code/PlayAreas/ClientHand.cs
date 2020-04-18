using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientHand : Hand<BadCard, BadCardAsset>
{
    [SerializeField] private int cardsToDrawEachRound;

    public override void Setup(Board board)
    {
        this.board = board;
    }

    public override void StartTurn()
    {
        for (int i = 0; i < cardsToDrawEachRound; i++)
        {
            AddCard(board.DrawBadCard());
        }
    }
}
