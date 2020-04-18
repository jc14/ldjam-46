using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card/RepairCard")]
public class RepairCardAsset : CardAsset
{
    [SerializeField] private int repairAmount;
}
