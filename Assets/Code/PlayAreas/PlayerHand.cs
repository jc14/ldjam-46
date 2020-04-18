using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : Hand<RepairCard, RepairCardAsset>
{
    [Range(1, 10)]
    [SerializeField] private int cardsToStart = 5;

    public override void Setup(Board board)
    {
        Clear();
        this.board = board;

        for (int i = 0; i < cardsToStart; i++)
        {
            AddCard(board.DrawRepairCard());
        }
    }

    public override void StartTurn()
    {
        
    }
}
