using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CaseNumberPanel : MonoBehaviour
{
    public TMP_Text Text;

    private void Awake()
    {
        Text.text = "Case: N/A";
    }

    public void SetCaseNumber(int caseNumber)
    {
        Text.text = "Case: " + caseNumber;
    }
}
