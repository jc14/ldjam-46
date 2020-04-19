using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hand<TCard, TAsset> : MonoBehaviour where TCard : Card<TAsset> where TAsset : CardAsset
{
    [SerializeField] private Transform cardsContent;

    protected Board board;

    private List<TCard> cards;

    private void Awake()
    {
        cards = new List<TCard>();
    }

    public void AddCard(TCard card)
    {
        if (cards.Count >= GetMaxCardsCount())
            return;

        cards.Add(card);
        card.transform.SetParent(cardsContent);
    }

    public void RemoveCard(TCard card)
    {
        cards.Remove(card);
        card.Delete();
    }

    public TCard[] GetCards()
    {
        return cards.ToArray();
    }

    /// <summary>
    /// Removes all cards from hand.
    /// </summary>
    public void Clear()
    {
        while (cards.Count > 0)
        {
            RemoveCard(cards[0]);
        }
    }

    public abstract void Setup(Board board);
    public abstract void StartTurn();
    protected abstract int GetMaxCardsCount();
}
