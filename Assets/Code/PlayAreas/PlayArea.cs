using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayArea<TCard, TAsset> : MonoBehaviour where TCard : Card<TAsset> where TAsset : CardAsset
{
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
}
