using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public bool IsActive;

    public TutorialScreen TutorialScreen;

    private void Awake()
    {
        TutorialScreen.Close();
    }

    public void Display(bool isActive)
    {
        if (isActive)
            TutorialScreen.OpenScreen();
        else
            TutorialScreen.Close();
    }
}
