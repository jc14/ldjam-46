using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAsset : ScriptableObject
{
    [SerializeField] private bool isEnabled = false;
    [SerializeField] private string title;
    [TextArea()]
    [SerializeField] private string description;

    public bool IsEnabled => isEnabled;
    public string Title => title;
    public string Description => description;
}
