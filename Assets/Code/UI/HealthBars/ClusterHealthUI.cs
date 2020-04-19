using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClusterHealthUI : MonoBehaviour
{
    public HealthBarUI RelationshipHealth;
    public HealthBarUI ShieldHealth;

    public void Setup(Client client)
    {
        RelationshipHealth.Setup(client.MaxHealth);
    }

    public void Render(Client client)
    {
        RelationshipHealth.SetCurrentValue(client.RelationshipHealth);
    }
}
