using System.Text;
using TMPro;
using UnityEngine.UI;

public class EndGameScreen : AbstractScreen
{
    public TMP_Text ResultText;
    public TMP_Text DescriptionText;
    public Button ReturnToMainMenuButton;

    private const string prefixText = "This horrible relationship finally comes to an end. You did as well as anyone in this position would have done, I guess. Cupid Arrow Inc. thanks you for your work, but your pay will be deducted. Cases fail but the company would rather no cases to fail, so, what can we do. Anyways, continue working.";

    private const string oneSidedBreakUp = "{l} can only take so much. {l} finally worked up the courage and ended it with {c}. If {c} could get their shit together then maybe the relationship could have continued. I guess we'll never know.";

    private const string mutualBreakUp = "{c} and {l} finally realized how shit their relationship was. The constant back and forth was too much. They have agreed to break up mutually. At least that's something, I guess.";

    private void Awake()
    {
        ReturnToMainMenuButton.onClick.AddListener(HandleReturnToMainMenu);
    }

    protected override void UpdateScreen(Board board)
    {
        ResultText.text = $"Relationship Lasted {board.TurnsCompleted} Turns";

        StringBuilder sb = new StringBuilder();
        sb.AppendLine(prefixText);
        sb.AppendLine();

        sb.AppendLine(GetBreakUpText(board.Client1, board.Client2));

        DescriptionText.text = sb.ToString();
    }

    private string GetBreakUpText(Client client1, Client client2)
    {
        if (client1.RelationshipHealth <= 0 && client2.RelationshipHealth <= 0)
            return StringTemplate.ParseAndReplaceTemplate(mutualBreakUp, client1, client2);

        if (client1.RelationshipHealth <= 0)
            return StringTemplate.ParseAndReplaceTemplate(oneSidedBreakUp, client2, client1);

        // Must be client2 that broke up, return that description.
        return StringTemplate.ParseAndReplaceTemplate(oneSidedBreakUp, client1, client2);
    }

    private void HandleReturnToMainMenu()
    {
        gameManager.ToggleMainMenu();
    }
}
