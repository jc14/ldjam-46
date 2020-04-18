using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public GameManager GameManager;
    [Space(10)]
    public GameObject RepairCardPrefab;

    public bool IsPlayingGame { get; private set; } = false;

    private CardAssetFactory<RepairCardAsset> repairCardFactory;

    private Hand hand;

    private void Awake()
    {
        hand = GetComponentInChildren<Hand>();

        repairCardFactory = new CardAssetFactory<RepairCardAsset>();
    }

    public void StartNewGame()
    {
        Debug.Log("New game bitches!!!");
        IsPlayingGame = true;
    }

    [ContextMenu("End Game")]
    public void EndGame()
    {
        IsPlayingGame = false;
        // TODO: I think I'm setting myself up for failure here...
        GameManager.ToggleMainMenu();
    }

    public void HandleMainMenuToggle()
    {
        GameManager.ToggleMainMenu();
    }

    [ContextMenu("Draw Repair Card")]
    public void DrawRepairCard()
    {
        GameObject go = Instantiate(RepairCardPrefab);
        RepairCard newCard = go.GetComponent<RepairCard>();
        newCard.SetAsset(repairCardFactory.GetRandomCard());

        hand.AddCard(newCard);
    }
}
