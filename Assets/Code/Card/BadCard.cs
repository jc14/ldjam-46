using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BadCard : Card<BadCardAsset>
{
    public TMP_Text DamageText;

    public int Damage => remainingDamage;

    private ClientHand hand;
    private Client client;

    private int remainingDamage;

    public void SetClientHand(ClientHand hand)
    {
        this.hand = hand;
    }

    public void Repair(int amount)
    {
        Debug.Log($"Repairing {remainingDamage} with {amount}");

        remainingDamage -= amount;

        if (remainingDamage <= 0)
            hand.RemoveCard(this);

        Render();
    }

    public void Initialize(Client target)
    {
        client = target;
        remainingDamage = asset.Damage;

        Render();
    }

    private string ParseAndReplaceTemplate(string description)
    {
        string result = description;
        result = result.Replace("{lover}", client.Lover.FirstName);
        result = result.Replace("{client}", client.FirstName);
        return result;
    }

    protected override void OnLeftClick()
    {
        board.RepairBadCard(this);
    }

    protected override void OnRightClick()
    {
        Debug.Log($"Right clicked! {asset.Title}");
    }

    protected override void OnRender()
    {
        DamageText.text = remainingDamage.ToString();

        if (client != null)
            DescriptionText.text = ParseAndReplaceTemplate(asset.Description);
    }
}
