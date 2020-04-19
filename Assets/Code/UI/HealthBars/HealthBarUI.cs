using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private GameObject CellPrefab;
    [Space(10)]
    [SerializeField] private Color32 FilledColor;
    [SerializeField] private Color32 EmptyColor;

    private List<CellUI> cells;

    private void Awake()
    {
        cells = new List<CellUI>();
    }

    public void Setup(int maxValue)
    {
        Clear();

        for (int i = 0; i < maxValue; i++)
        {
            GameObject go = Instantiate(CellPrefab, transform);
            cells.Insert(0, go.GetComponent<CellUI>());
        }
    }

    public void SetCurrentValue(int value)
    {
        for (int i = 0; i < cells.Count; i++)
        {
            if (i < value)
            {
                cells[i].SetColor(FilledColor);
                continue;
            }

            cells[i].SetColor(EmptyColor);
        }
    }

    private void Clear()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        cells.Clear();
    }
}
