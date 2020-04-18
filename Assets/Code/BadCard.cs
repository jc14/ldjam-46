using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadCard : Card<BadCardAsset>
{
    public int Damage => asset.Damage;
}
