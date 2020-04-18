using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardAssetFactory<T> where T : CardAsset
{
    public T[] cardPool;

    public CardAssetFactory()
    {
        List<T> filtered = new List<T>();

        foreach (T cardAsset in Resources.LoadAll<T>("Cards"))
        {
            if (cardAsset.IsEnabled)
            {
                filtered.Add(cardAsset);
            }
        }

        cardPool = filtered.ToArray();
    }

    public T GetRandomCard()
    {
        if (cardPool.Length == 0)
        {
            Debug.LogError($"Card pool is empty!");
        }

        return cardPool[Random.Range(0, cardPool.Length)];
    }
}
