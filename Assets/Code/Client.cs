using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    [SerializeField] private string firstName;
    public string FirstName => firstName;

    private float relationshipHealth;
    public float RelationshipHealth => relationshipHealth / settings.HealthPoints;

    private ClientSettings settings;
    private BadHand hand;
    private ClientUI ui;

    private void Awake()
    {
        hand = GetComponent<BadHand>();
        ui = GetComponent<ClientUI>();
    }

    public void Setup(Board board, ClientSettings settings)
    {
        this.settings = settings;

        relationshipHealth = settings.HealthPoints;

        hand.Setup(board);

        ui.Render(this);
    }

    public void StartTurn()
    {
        hand.StartTurn();

        // TODO: Loop over cards and apply damage
        foreach (BadCard card in hand.GetCards())
        {
            ApplyDamage(card.Damage);
        }
    }

    private void ApplyDamage(int amount)
    {
        relationshipHealth -= amount;

        ui.Render(this);
    }
}
