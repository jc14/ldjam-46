using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientHand : Hand<BadCard, BadCardAsset>
{
    [SerializeField] private int cardsToDrawEachRound;

    private Client client;

    public override void Setup(Board board)
    {
        this.board = board;
    }

    public override void StartTurn()
    {
        for (int i = 0; i < cardsToDrawEachRound; i++)
        {
            BadCard newCard = board.DrawBadCard();
            AddCard(newCard);
            newCard.SetClientHand(this);
        }
    }

    public void SetClient(Client client)
    {
        this.client = client;
    }
}
