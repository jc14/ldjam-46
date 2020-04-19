using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClientUI : MonoBehaviour
{
    public TMP_Text ClientNameText;
    public ClusterHealthUI clusterHealthUI;

    public void Setup(Client client)
    {
        clusterHealthUI.Setup(client);

        Render(client);
    }

    public void Render(Client client)
    {
        ClientNameText.text = client.FirstName;
        clusterHealthUI.Render(client);
    }
}
