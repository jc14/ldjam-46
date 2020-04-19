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
    private ClientHand hand;
    private ClientUI ui;
    private Client lover;
    public Client Lover => lover;

    private void Awake()
    {
        hand = GetComponent<ClientHand>();
        ui = GetComponent<ClientUI>();
    }

    public void Setup(Board board, Client lover, ClientSettings settings)
    {
        CleanUp();

        this.lover = lover;
        this.settings = settings;

        relationshipHealth = settings.HealthPoints;

        hand.Setup(board);
        hand.SetClient(this);

        ui.Render(this);
    }

    public void CleanUp()
    {
        hand.Clear();
    }

    public void StartTurn()
    {
        hand.StartTurn();

        // TODO: Loop over cards and apply damage
        foreach (BadCard card in hand.GetCards())
        {
            lover.ApplyDamage(card.Damage);
        }
    }

    public void ApplyDamage(int amount)
    {
        relationshipHealth -= amount;

        ui.Render(this);
    }
}
