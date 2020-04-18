using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    private List<RepairCard> cards;

    public void AddCard(RepairCard card)
    {
        cards.Add(card);
        card.transform.SetParent(transform);
    }
}
