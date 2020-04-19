using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewGameScreen : AbstractScreen
{
    public TMP_Text CaseNumberText;
    public TMP_Text DescriptionText;
    public TMP_InputField Client1NameInputField;
    public TMP_InputField Client2NameInputField;
    public Button StartCaseButton;

    private Board board;
    private int caseNumber;

    private const string descriptionText = "Thank you for contracting with Cupid's Arrow Inc.™ Difficult Cases Division. This division strives to keep successfully matched couples, that might be having a few difficulties, together. We work very hard to keep our matching success rate high and cases like these really challenge our excellence. This case presents two individuals that were matched with our incredible matching service that must have lied during the process. Somehow, these two, horrible individuals got through the matching process and we need you to keep the relationship alive. At least until they're married and we aren't liable for their relationship anymore. Good luck and don't fail.";

    private void Awake()
    {
        StartCaseButton.onClick.AddListener(HandleStartCase);
        Client1NameInputField.onValueChanged.AddListener(HandleClient1NameTextChange);
        Client2NameInputField.onValueChanged.AddListener(HandleClient2NameTextChange);
    }

    protected override void UpdateScreen(Board board)
    {
        caseNumber = Random.Range(1, 999999);

        this.board = board;

        CaseNumberText.text = "Case " + caseNumber;
        DescriptionText.text = descriptionText;
    }

    private void HandleStartCase()
    {
        board.StartNewGame(caseNumber);
        Close();
    }

    private void HandleClient1NameTextChange(string name)
    {
        HandleClientNameChange(board.Client1, name, Client1NameInputField);
    }

    private void HandleClient2NameTextChange(string name)
    {
        HandleClientNameChange(board.Client2, name, Client2NameInputField);
    }

    private void HandleClientNameChange(Client client, string name, TMP_InputField inputField)
    {
        client.SetFirstName(name);

        inputField.text = client.FirstName;
    }
}
