using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card/BadCard")]
public class BadCardAsset : CardAsset
{
    [SerializeField] private int damageAmount;
}
