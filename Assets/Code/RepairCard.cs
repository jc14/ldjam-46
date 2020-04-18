using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairCard : Card
{
    [SerializeField] private RepairCardAsset asset;

    private Hand hand;

    private void Awake()
    {
        
    }

    public void SetHand(Hand hand)
    {
        this.hand = hand;
    }

    public void SetAsset(RepairCardAsset asset)
    {
        this.asset = asset;
        Render();
    }

    private void Render()
    {
        Render(asset.Title, asset.Description);
    }
}
