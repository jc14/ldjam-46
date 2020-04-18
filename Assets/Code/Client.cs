using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    [SerializeField] private string firstName;
    public string FirstName => firstName;

    private float relationshipHealth;
    public float RelationshipHealth => relationshipHealth;

    private BadHand hand;
    private ClientUI ui;

    private void Awake()
    {
        hand = GetComponent<BadHand>();
        ui = GetComponent<ClientUI>();
    }

    public void Setup()
    {
        relationshipHealth = 1;

        ui.Render(this);
    }
}
