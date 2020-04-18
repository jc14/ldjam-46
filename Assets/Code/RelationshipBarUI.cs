using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelationshipBarUI : MonoBehaviour
{
    [Range(0f, 1f)]
    public float Health;
    [Space(15)]
    public RectTransform root;
    public RectTransform ValueBar;

    private void Update()
    {
        float size = root.rect.height;

        Vector2 temp = ValueBar.sizeDelta;
        temp.y = size * Health;
        ValueBar.sizeDelta = temp;
    }

    public void Render(Client client)
    {
        Health = client.RelationshipHealth;
    }
}
