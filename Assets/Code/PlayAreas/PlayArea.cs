using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayArea<TCard, TAsset> : MonoBehaviour where TCard : Card<TAsset> where TAsset : CardAsset
{
    protected Board board;

    private List<TCard> cards;

    private void Awake()
    {
        cards = new List<TCard>();
    }

    public void AddCard(TCard card)
    {
        cards.Add(card);
        card.transform.SetParent(transform);
    }

    public abstract void Setup(Board board);
    public abstract void StartTurn();
}
