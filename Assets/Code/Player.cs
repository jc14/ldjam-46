﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public RepairCard SelectedCard => hand.selectedCard;

    private PlayerHand hand;

    private void Awake()
    {
        hand = GetComponent<PlayerHand>();
    }

    public void Setup(Board board)
    {
        CleanUp();

        hand.Setup(board);
    }

    public void CleanUp()
    {
        hand.Clear();
    }

    public void StartTurn()
    {
        hand.StartTurn();
    }

    public void DeselectCard()
    {
        hand.DeselectCard();
    }

    public void DiscardSelectedCard()
    {
        hand.DiscardSelectedCard();
    }
}
