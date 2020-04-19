using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : Hand<RepairCard, RepairCardAsset>
{
    [Range(1, 10)]
    [SerializeField] private int cardsToStart = 5;

    public RepairCard selectedCard;

    public override void Setup(Board board)
    {
        Clear();
        this.board = board;

        for (int i = 0; i < cardsToStart; i++)
        {
            DrawNewCard();
        }
    }

    public override void StartTurn()
    {
        DrawNewCard();
    }

    public void SelectCard(RepairCard card)
    {
        if (selectedCard != null)
            DeselectCard();

        selectedCard = card;
        card.Select();
    }

    public void DeselectCard()
    {
        if (selectedCard != null)
        {
            selectedCard.Deselect();
            selectedCard = null;
        }
    }

    public void DiscardSelectedCard()
    {
        RemoveCard(selectedCard);
        DeselectCard();
    }

    private void DrawNewCard()
    {
        RepairCard newCard = board.DrawRepairCard();
        AddCard(newCard);
        newCard.SetPlayerHand(this);
    }

    protected override int GetMaxCardsCount()
    {
        return 7;
    }
}
