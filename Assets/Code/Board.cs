﻿using System.Collections;
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
    public int CaseNumber { get; private set; }
    public float ExtraRepairCardsToAdd { get; private set; }

    [Space(10)]
    [Range(0.1f, 2)]
    public float RepairCardsToAddPerBadDestroyed = 1;

    public AudioManager Audio { get; private set; }

    private CardAssetFactory<RepairCardAsset> repairCardFactory;
    private CardAssetFactory<BadCardAsset> badCardFactory;

    private BoardUI boardUI;

    private Player player;
    private Client client1;
    private Client client2;

    private Tutorial tutorial;

    public bool IsTutorialActive
    {
        get
        {
            return tutorial.IsActive;
        }
        set
        {
            tutorial.IsActive = value;
        }
    }

    public Client Client1 => client1;
    public Client Client2 => client2;

    private void Awake()
    {
        Audio = GetComponentInChildren<AudioManager>();

        player = transform.Find("Player").GetComponent<Player>();
        client1 = transform.Find("Client 1").GetComponent<Client>();
        client2 = transform.Find("Client 2").GetComponent<Client>();

        repairCardFactory = new CardAssetFactory<RepairCardAsset>();
        badCardFactory = new CardAssetFactory<BadCardAsset>();

        boardUI = GetComponent<BoardUI>();
        tutorial = GetComponent<Tutorial>();
    }

    public void StartNewGame(int caseNumber)
    {
        CaseNumber = caseNumber;

        Debug.Log("New game bitches!!!");
        IsPlayingGame = true;
        TurnsCompleted = 0;

        player.Setup(this);
        client1.Setup(this, client2, clientSettings);
        client2.Setup(this, client1, clientSettings);

        boardUI.OnStartNewGame();

        tutorial.Display(IsTutorialActive);

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

        ExtraRepairCardsToAdd = 0;
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

        Audio.PlayPlacePlayer();
        player.DiscardSelectedCard();
    }

    public void OnBadCardDestroyed(BadCard card)
    {
        ExtraRepairCardsToAdd += RepairCardsToAddPerBadDestroyed;
    }
}
