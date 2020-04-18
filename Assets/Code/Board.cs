using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    private CardAssetFactory<RepairCardAsset> repairCardFactory;

    private Hand hand;

    private void Awake()
    {
        hand = GetComponentInChildren<Hand>();

        repairCardFactory = new CardAssetFactory<RepairCardAsset>();
    }

    public void DrawRepairCard()
    {
        //hand.AddCard();
    }
}
