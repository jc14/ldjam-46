using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClientUI : MonoBehaviour
{
    public TMP_Text ClientNameText;
    public RelationshipBarUI relationshipBar;

    public void Render(Client client)
    {
        ClientNameText.text = client.FirstName;
        relationshipBar.Render(client);
    }
}
