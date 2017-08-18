using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputController : MonoBehaviour {
    public KeyCode Monster1Button;
    public KeyCode Monster2Button;

    public Action OnMonster1ButtonPressed;
    public Action OnMonster2ButtonPressed;

    private void Update()
    {
        if (OnMonster1ButtonPressed != null && Input.GetKeyDown(Monster1Button))
        {
            OnMonster1ButtonPressed();
        }

        if (OnMonster2ButtonPressed != null && Input.GetKeyDown(Monster2Button))
        {
            OnMonster2ButtonPressed();
        }
    }
}