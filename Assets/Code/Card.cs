using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Card<T> : MonoBehaviour where T : CardAsset
{
    public T asset;

    public TMP_Text titleText;
    public TMP_Text descriptionText;

    public void Render(string title, string description)
    {
        titleText.text = title;
        descriptionText.text = description;
    }

    public void SetAsset(T asset)
    {
        this.asset = asset;
        Render();
    }

    public void Delete()
    {
        Destroy(gameObject);
    }

    private void Render()
    {
        Render(asset.Title, asset.Description);
    }
}
