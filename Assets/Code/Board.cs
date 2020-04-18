using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    public GameManager GameManager;
    [Space(10)]
    public ClientSettings clientSettings;
    [Space(10)]
    public GameObject RepairCardPrefab;
    public GameObject BadCardPrefab;

    public bool IsPlayingGame { get; private set; } = false;

    private CardAssetFactory<RepairCardAsset> repairCardFactory;
    private CardAssetFactory<BadCardAsset> badCardFactory;

    private Hand playerHand;
    private Client client1;
    private Client client2;

    private void Awake()
    {
        playerHand = GetComponentInChildren<Hand>();

        client1 = transform.Find("Client 1").GetComponent<Client>();
        client2 = transform.Find("Client 2").GetComponent<Client>();

        repairCardFactory = new CardAssetFactory<RepairCardAsset>();
        badCardFactory = new CardAssetFactory<BadCardAsset>();
    }

    public void StartNewGame()
    {
        Debug.Log("New game bitches!!!");
        IsPlayingGame = true;

        playerHand.Setup(this);
        client1.Setup(this, clientSettings);
        client2.Setup(this, clientSettings);

        StartRound();
    }

    [ContextMenu("End Game")]
    public void EndGame()
    {
        Debug.Log("Game over bitches!!!");
        IsPlayingGame = false;
        // TODO: I think I'm setting myself up for failure here...
        GameManager.ToggleMainMenu();
    }

    public void StartRound()
    {
        Debug.Log("New round bitches!!!");
        playerHand.StartTurn();

        client1.StartTurn();
        client2.StartTurn();
    }

    public void EndRound()
    {
        Debug.Log("End round bitches!!!");
    }

    public void HandleMainMenuToggle()
    {
        GameManager.ToggleMainMenu();
    }

    [ContextMenu("Draw Repair Card")]
    public RepairCard DrawRepairCard()
    {
        GameObject go = Instantiate(RepairCardPrefab);
        RepairCard newCard = go.GetComponent<RepairCard>();
        newCard.SetAsset(repairCardFactory.GetRandomCard());

        return newCard;
    }

    [ContextMenu("Draw Bad Card")]
    public BadCard DrawBadCard()
    {
        GameObject go = Instantiate(BadCardPrefab);
        BadCard newCard = go.GetComponent<BadCard>();
        newCard.SetAsset(badCardFactory.GetRandomCard());

        return newCard;
    }
}
