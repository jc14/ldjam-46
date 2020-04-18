using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public GameObject repairCardPrefab;

    private CardAssetFactory<RepairCardAsset> repairCardFactory;

    private Hand hand;

    private void Awake()
    {
        hand = GetComponentInChildren<Hand>();

        repairCardFactory = new CardAssetFactory<RepairCardAsset>();
    }

    public void DrawRepairCard()
    {
        GameObject go = Instantiate(repairCardPrefab);
        RepairCard newCard = go.GetComponent<RepairCard>();
        newCard.SetAsset(repairCardFactory.GetRandomCard());

        hand.AddCard(newCard);
    }
}
