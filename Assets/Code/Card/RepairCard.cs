using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RepairCard : Card<RepairCardAsset>
{
    private PlayerHand hand;

    public void SetPlayerHand(PlayerHand hand)
    {
        this.hand = hand;
    }

    public void Select()
    {
        animator.SetBool("IsSelected", true);
    }

    public void Deselect()
    {
        animator.SetBool("IsSelected", false);
    }

    protected override void OnLeftClick()
    {
        hand.SelectCard(this);
    }

    protected override void OnRightClick()
    {
        
    }
}
