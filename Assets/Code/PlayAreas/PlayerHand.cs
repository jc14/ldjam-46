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
        for (int i = 0; i < Mathf.FloorToInt(board.ExtraRepairCardsToAdd); i++)
        {
            DrawNewCard();
        }
    }

    public void SelectCard(RepairCard card)
    {
        // Trying to select the same card.
        if (selectedCard == card)
            return;

        if (selectedCard != null)
            DeselectCard();

        board.Audio.PlaySelectPlayer();

        selectedCard = card;
        card.Select();
    }

    public void DeselectCard()
    {
        if (selectedCard != null)
        {
            board.Audio.PlayDeselectPlayer();

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
        return 6;
    }
}
