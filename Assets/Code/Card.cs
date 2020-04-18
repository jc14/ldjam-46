using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Card : MonoBehaviour
{
    public TMP_Text titleText;
    public TMP_Text descriptionText;

    public void Render(string title, string description)
    {
        titleText.text = title;
        descriptionText.text = description;
    }
}
