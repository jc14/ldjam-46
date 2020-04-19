using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientHand : Hand<BadCard, BadCardAsset>
{
    [SerializeField] private int cardsToDrawEachRound = 1;

    private Client client;

    public override void Setup(Board board)
    {
        this.board = board;
    }

    public override void StartTurn()
    {
        for (int i = 0; i < cardsToDrawEachRound; i++)
        {
            DrawCardToHand();
        }
    }

    public void SetClient(Client client)
    {
        this.client = client;
    }

    private void DrawCardToHand()
    {
        BadCard newCard = board.DrawBadCard(client);
        AddCard(newCard);
        newCard.SetClientHand(this);
    }

    protected override int GetMaxCardsCount()
    {
        return 3;
    }
}
