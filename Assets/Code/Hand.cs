using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    private List<RepairCard> cards;

    private void Awake()
    {
        cards = new List<RepairCard>();
    }

    public void AddCard(RepairCard card)
    {
        cards.Add(card);
        card.transform.SetParent(transform);
        card.SetHand(this);
    }
}
