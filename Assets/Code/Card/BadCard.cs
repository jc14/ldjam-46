using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadCard : Card<BadCardAsset>
{
    public int Damage => asset.Damage;

    protected override void OnLeftClick()
    {
        throw new System.NotImplementedException();
    }

    protected override void OnRightClick()
    {
        throw new System.NotImplementedException();
    }
}
