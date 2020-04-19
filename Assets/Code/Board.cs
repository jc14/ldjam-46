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
    public int TurnsCompleted { get; private set; } = 0;

    private CardAssetFactory<RepairCardAsset> repairCardFactory;
    private CardAssetFactory<BadCardAsset> badCardFactory;

    private Player player;
    private Client client1;
    private Client client2;

    public Client Client1 => client1;
    public Client Client2 => client2;

    private void Awake()
    {
        player = transform.Find("Player").GetComponent<Player>();
        client1 = transform.Find("Client 1").GetComponent<Client>();
        client2 = transform.Find("Client 2").GetComponent<Client>();

        repairCardFactory = new CardAssetFactory<RepairCardAsset>();
        badCardFactory = new CardAssetFactory<BadCardAsset>();
    }

    public void StartNewGame()
    {
        Debug.Log("New game bitches!!!");
        IsPlayingGame = true;
        TurnsCompleted = 0;

        player.Setup(this);
        client1.Setup(this, client2, clientSettings);
        client2.Setup(this, client1, clientSettings);

        StartRound();
    }

    public void EndGame()
    {
        Debug.Log("Game over bitches!!!");
        IsPlayingGame = false;
        GameManager.OpenEndGameScreen();
    }

    public void StartRound()
    {
        Debug.Log("New round bitches!!!");
        player.StartTurn();

        client1.StartTurn();
        client2.StartTurn();
    }

    public void EndRound()
    {
        client1.EndTurn();
        client2.EndTurn();

        // You have lost. The case is terminated and the company is very displeased.
        if (client1.RelationshipHealth <= 0 || client2.RelationshipHealth <= 0)
        {
            EndGame();
            return;
        }

        TurnsCompleted++;

        StartRound();
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
        newCard.Setup(this, repairCardFactory.GetRandomCard());
        newCard.Initialize();

        return newCard;
    }

    [ContextMenu("Draw Bad Card")]
    public BadCard DrawBadCard(Client target)
    {
        GameObject go = Instantiate(BadCardPrefab);
        BadCard newCard = go.GetComponent<BadCard>();
        newCard.Setup(this, badCardFactory.GetRandomCard());
        newCard.Initialize(target);

        return newCard;
    }

    public void RepairBadCard(BadCard card)
    {
        Debug.Log("Repair!");
        card.Repair(player.SelectedCard.RepairAmount);

        player.DiscardSelectedCard();
    }
}
