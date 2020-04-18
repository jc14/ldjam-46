using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Board Board;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Board.HandleMainMenuToggle();
        }
    }
}
