using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    [SerializeField] private string firstName;
    public string FirstName => firstName;

    private int relationshipHealth;
    public int RelationshipHealth => relationshipHealth;
    public int MaxHealth => settings.HealthPoints;

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

        relationshipHealth = MaxHealth;

        hand.Setup(board);
        hand.SetClient(this);

        ui.Setup(this);
    }

    public void CleanUp()
    {
        hand.Clear();
    }

    public void StartTurn()
    {
        hand.StartTurn();
    }

    public void EndTurn()
    {
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

    public void SetFirstName(string name)
    {
        int maxLength = 25;

        if (name.Length > maxLength)
        {
            firstName = name.Substring(0, maxLength);
            return;
        }

        firstName = name;
    }
}
